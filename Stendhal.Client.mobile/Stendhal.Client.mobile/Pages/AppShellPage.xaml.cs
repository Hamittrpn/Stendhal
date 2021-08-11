using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stendhal.Client.mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellPage : Shell
    {
        public AppShellPage()
        {
            InitializeComponent();
        }
    }
}