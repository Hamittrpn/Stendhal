using Stendhal.Client.mobilebase.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Stendhal.Client.mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        public ICommand DialogCommand => new Command(() =>
        {
            DialogService.AlertAsync("Dialog Service", "Test", "Ok");
        });

        public ICommand GoToListPageCommand => new Command(() =>
        {
            NavigationService.NavigateToAsync<ListPageViewModel>();
        });

        public ICommand GoToTestPageCommand => new Command(() =>
        {
            NavigationService.NavigateToAsync<TestPageViewModel>();
        });

        public ICommand GoToAudioPageCommand => new Command(() =>
        {
            NavigationService.NavigateToAsync<AudioPlayerPageViewModel>();
        });
    }
}
