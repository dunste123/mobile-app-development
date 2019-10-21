using ShittyCSharpApp.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ShittyCSharpApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            WebStuffDSte.InitDSte();

            MainPage = new SideMenu();
            
//            NavigationPage.SetHasBackButton(MainPage, false);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
