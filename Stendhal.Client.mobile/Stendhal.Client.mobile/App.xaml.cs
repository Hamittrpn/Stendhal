using Stendhal.Client.mobile.ViewModels;
using Stendhal.Client.mobilebase.Helper;
using Stendhal.Client.mobilebase.ViewModels.Base;
using System.Reflection;
using Xamarin.Forms;

namespace Stendhal.Client.mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            GlobalSetting.Instance.PagesPath = "Pages";
            GlobalSetting.Instance.ViewsPath = "Views";
            GlobalSetting.Instance.ViewModelPath = "ViewModels";
            GlobalSetting.Instance.UseAppCenter = true;
            GlobalSetting.Instance.AppCenterAndroidKey = "98336c7c-6215-44d5-a019-2614c0f7defd;";
            GlobalSetting.Instance.BaseEndpoint = "https://jsonplaceholder.typicode.com";

            ViewModelLocator.Init<AppShellPageViewModel>(Assembly.GetExecutingAssembly());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
