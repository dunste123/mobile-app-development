using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShittyCSharpApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly string regexDSte = @"rgba\(([0-9]+), ([0-9]+), ([0-9]+), ([0-9\.]+)\)";
        private bool isUpdatingDSte = false;
        private bool lockedDSte = false;

        public MainPage()
        {
            InitializeComponent();

            this.Title = "Color Mixer";
        }

        private async void BtnPopupClickedDSte(object sender, EventArgs e)
        {
            var ret = await DisplayAlert("Would you look at that", "It's an alert", "Ok", "Cancel");

#pragma warning disable CS4014
            if (ret)
            {
                DisplayAlert("Result", "You pressed Ok", "Ok");
            }
            else
            {
                DisplayAlert("Result", "You pressed Cancel", "Ok");
            }
#pragma warning restore CS4014
        }

        private void ColorSliderChangeDSte(object sender, EventArgs e)
        {
            if (isUpdatingDSte || lockedDSte)
            {
                return;
            }

            isUpdatingDSte = true;

            var red = (int)redSliderDSte.Value;
            var green = (int)greenSliderDSte.Value;
            var blue = (int)blueSliderDSte.Value;
            var op = opacitySliderDSte.Value;

            rgbaFieldDSte.Text = $"rgba({red}, {green}, {blue}, {op})";

            UpdateColorDisplayDSte();

            isUpdatingDSte = false;
        }

        private void ColorTextChangedDSte(object sender, EventArgs e)
        {
            if (isUpdatingDSte || lockedDSte)
            {
                return;
            }

            isUpdatingDSte = true;

            var value = rgbaFieldDSte.Text;

            if (Regex.IsMatch(value, regexDSte))
            {
                var match = Regex.Match(value, regexDSte);
                var groups = match.Groups;

                redSliderDSte.Value = int.Parse(groups[1].ToString());
                greenSliderDSte.Value = int.Parse(groups[2].ToString());
                blueSliderDSte.Value = int.Parse(groups[3].ToString());
                opacitySliderDSte.Value = double.Parse(groups[4].ToString());

            }

            UpdateColorDisplayDSte();

            isUpdatingDSte = false;
        }

        private void UpdateColorDisplayDSte()
        {
            var red = (int)redSliderDSte.Value;
            var green = (int)greenSliderDSte.Value;
            var blue = (int)blueSliderDSte.Value;

            colorDSte.Color = Color.FromRgb(red, green, blue);
        }

        private void CbLockDSte_CheckedChangedDSte(object sender, CheckedChangedEventArgs e)
        {
            lockedDSte = cbLockDSte.IsChecked;
        }
    }
}