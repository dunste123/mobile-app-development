using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShittyCSharpApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var ret = await DisplayAlert("Hello", "You just clicked the button", "Accept", "Accept Not");

            if (ret)
            {
                DisplayAlert("Alert", "Accepted", "Ok");
            }
            else
            {
                DisplayAlert("Alert", "Not Accepted", "Ok");
            }
        }
    }
}
