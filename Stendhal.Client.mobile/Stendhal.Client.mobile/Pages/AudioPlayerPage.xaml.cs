using Stendhal.Client.mobile.DependencyServices;
using Stendhal.Client.mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stendhal.Client.mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AudioPlayerPage : ContentPage
    {
        public AudioPlayerPage()
        {
            InitializeComponent();
            BindingContext = new AudioPlayerPageViewModel(DependencyService.Get<IAudioPlayerService>());
        }
    }
}