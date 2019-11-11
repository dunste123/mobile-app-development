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
        private const string RegexDSte = @"rgba\(([0-9]{1,3}), ([0-9]{1,3}), ([0-9]{1,3}), ([0-9\.]{1,3})\)";
        private bool _isUpdatingDSte = false;
        private bool _lockedDSte = false;

        public MainPage()
        {
            InitializeComponent();

            this.Title = "Color Mixer";
        }

        private async void BtnPopupClickedDSte(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FuckingPopUpPage());
        }

        private void ColorSliderChangeDSte(object sender, EventArgs e)
        {
            if (_isUpdatingDSte || _lockedDSte)
            {
                return;
            }

            Task.Run(() =>
            {
                _isUpdatingDSte = true;

                var red = (int)RedSliderDSte.Value;
                var green = (int)GreenSliderDSte.Value;
                var blue = (int)BlueSliderDSte.Value;
                var op = OpacitySliderDSte.Value;
                
                Device.BeginInvokeOnMainThread(() =>
                {
                    RgbaFieldDSte.Text = $"rgba({red}, {green}, {blue}, {op})";

                    UpdateColorDisplayDSte();
                });

                _isUpdatingDSte = false;
            });
        }

        private void ColorTextChangedDSte(object sender, EventArgs e)
        {
            if (_isUpdatingDSte || _lockedDSte)
            {
                return;
            }

            Task.Run(() =>
            {
                _isUpdatingDSte = true;

                var value = RgbaFieldDSte.Text;

                if (Regex.IsMatch(value, RegexDSte))
                {
                    var match = Regex.Match(value, RegexDSte);
                    var groups = match.Groups;

                    RedSliderDSte.Value = int.Parse(groups[1].ToString());
                    GreenSliderDSte.Value = int.Parse(groups[2].ToString());
                    BlueSliderDSte.Value = int.Parse(groups[3].ToString());
                    OpacitySliderDSte.Value = double.Parse(groups[4].ToString());

                }

                Device.BeginInvokeOnMainThread(UpdateColorDisplayDSte);

                _isUpdatingDSte = false;
            });
        }

        private void UpdateColorDisplayDSte()
        {
            var red = (int)RedSliderDSte.Value;
            var green = (int)GreenSliderDSte.Value;
            var blue = (int)BlueSliderDSte.Value;

            ColorDSte.Color = Color.FromRgb(red, green, blue);
        }

        private void CbLockDSte_CheckedChangedDSte(object sender, CheckedChangedEventArgs e)
        {
            _lockedDSte = CbLockDSte.IsChecked;
        }
    }
}