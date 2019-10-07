using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShittyCSharpApp.Views;
using ShittyCSharpApp.Views.Menu;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ShittyCSharpApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            WebStuff.InitDSte();

            MainPage = new SideMenu();
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
