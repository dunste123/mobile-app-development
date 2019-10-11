using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace ShittyCSharpApp.Views
{
    public partial class AnimalPage : ContentPage
    {
        public List<string> apis = new List<string> {
            "llama",
            "cat",
            "duck",
            "alpaca",
            "seal",
            "camel",
            "dog",
            "fox",
            "lizard"
        };


        string selectedApi;

        public AnimalPage()
        {
            InitializeComponent();

            this.Title = "Animals";

            selectedApi = apis[0];

            ApiDropdownDSte.ItemsSource = apis;
            ApiDropdownDSte.SelectedIndex = 0;

            ActivityDSte.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
            ActivityDSte.BindingContext = AnimalDSte;

            ImageBtnDSte.Source = ImageSource.FromResource("ShittyCSharpApp.Assets.Img.wood_button.png");

            AnimalDSte.Source = ImageSource.FromStream(() => GetImageStreamDSte("https://cdn.duncte123.me/pnXTWOrbbp"));
        }

        private async void Button_ClickedDSte(object sender, EventArgs e)
        {
            Console.WriteLine($"https://apis.duncte123.me/animal/{selectedApi}");

            var response = await WebStuff.GetStringDSte($"https://apis.duncte123.me/animal/{selectedApi}");
            JObject obj = JObject.Parse(response);
            var imgUrl = (string)obj.SelectToken("data.file");

            Console.WriteLine(imgUrl);

            AnimalDSte.Source = ImageSource.FromStream(() => GetImageStreamDSte(imgUrl));
        }

        private void Picker_SelectedIndexChangedDSte(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var index = picker.SelectedIndex;

            if (index == -1)
            {
                selectedApi = apis[0];
            }
            else
            {
                selectedApi = apis[index];
            }

        }

        private Stream GetImageStreamDSte(string url)
        {
            return WebStuff.GetStreamSyncDSte(url);
        }
    }
}
