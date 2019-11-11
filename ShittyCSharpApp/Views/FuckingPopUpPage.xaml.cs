using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShittyCSharpApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuckingPopUpPage : ContentPage
    {
        public FuckingPopUpPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void BtnBackClickedDSte(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void BtnPopupClickedDSte(object sender, EventArgs e)
        {
            var ret = await DisplayAlert("Would you look at that", "It's an alert", "Ok", "Cancel");

#pragma warning disable CS4014
            DisplayAlert("Result", ret ? "You pressed Ok" : "You pressed Cancel", "Ok");
#pragma warning restore CS4014
        }
    }
}