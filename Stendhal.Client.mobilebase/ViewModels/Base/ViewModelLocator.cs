using Autofac;
using Rg.Plugins.Popup.Pages;
using Stendhal.Client.mobilebase.Helper;
using Stendhal.Client.mobilebase.Selectors.implementations;
using Stendhal.Client.mobilebase.Selectors.interfaces;
using Stendhal.Client.mobilebase.Services;
using Stendhal.Client.mobilebase.Services.Navigation;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace Stendhal.Client.mobilebase.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static IContainer _container;
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator),
                default(bool), propertyChanged: OnAutoWireViewModelChanged);
        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }
        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }
        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
                return;

            var viewType = view.GetType();
            string viewName = "";
            if (view is PopupPage)
                viewName = viewType.FullName.Replace($".{GlobalSetting.Instance.ViewsPath}.",
                    $".{GlobalSetting.Instance.ViewModelPath}.");
            else if (view is Page)
                viewName = viewType.FullName.Replace($".{GlobalSetting.Instance.PagesPath}.",
                    $".{GlobalSetting.Instance.ViewModelPath}.");

            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture,
                "{0}ViewModel, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
                return;
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
        /// <summary>
        /// Use GlobalSetting before Init
        /// </summary>
        /// <param name="assembly"></param>
        public static void Init<TViewModel>(Assembly assembly) where TViewModel : ViewModelBase
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => t.Namespace.Contains(GlobalSetting.Instance.ViewModelPath));
            builder.RegisterAssemblyTypes(assembly)
               .Where(t => t.Namespace.Contains(GlobalSetting.Instance.ViewModelPath));

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AssignableTo<IServiceBase>()
                   .AsImplementedInterfaces()
                   .SingleInstance();

            builder.RegisterGeneric(typeof(ApiRequest<>)).
                As(typeof(IApiRequest<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(ApiRequestSelector<>)).
               As(typeof(IApiRequestSelector<>)).InstancePerDependency();

            if (_container != null)
                _container.Dispose();

            _container = builder.Build();

            if (GlobalSetting.Instance.UseAppCenter)
            {
                var _appCenter = Resolve<Services.Appcenter.IAppCenterService>();
                _appCenter.Init();
            }

            var navigationService = Resolve<INavigationService>();
            navigationService.InitializeAsync<TViewModel>();
        }
    }
}
