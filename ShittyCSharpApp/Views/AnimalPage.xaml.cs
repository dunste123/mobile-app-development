using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace ShittyCSharpApp.Views
{
    public partial class AnimalPage : ContentPage
    {
        private List<string> _apisDSte { get; set; } = new List<string> {
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

        public List<string> ApisDSte
        {
            get => _apisDSte;
            set
            {
                _apisDSte = value;
                base.OnPropertyChanged();
            }
        }

        public string SelectedApi { get; set; } = "llama";

        public int SelectedApiIndex => this.ApisDSte.IndexOf(this.SelectedApi);

        public AnimalPage()
        {
            this.BindingContext = this;
            
            InitializeComponent();

            LoadApisDSte();

            this.Title = "Animals";

            this.ActivityDSte.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
            this.ActivityDSte.BindingContext = AnimalDSte;

            this.ImageBtnDSte.Source = ImageSource.FromResource("ShittyCSharpApp.Assets.Img.wood_button.png");
            
            LoadImageDSte("https://cdn.duncte123.me/pnXTWOrbbp");
        }

        private async void LoadApisDSte()
        {
            var response = await WebStuffDSte.GetStringDSte("https://apis.duncte123.me/animal");
            var obj = JObject.Parse(response);
            var animals = obj.Value<JArray>("data").ToObject<List<string>>();

            ApisDSte = animals;
        }

        private async void Button_ClickedDSte(object sender, EventArgs e)
        {
            var apiEndpoint = $"https://apis.duncte123.me/animal/{SelectedApi}";
            
            Console.WriteLine(apiEndpoint);

            var response = await WebStuffDSte.GetStringDSte(apiEndpoint);
            var obj = JObject.Parse(response);
            var imgUrl = obj.SelectToken("data.file").ToString();

            Console.WriteLine(imgUrl);

            this.LoadImageDSte(imgUrl);
        }

        private void Picker_SelectedIndexChangedDSte(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var index = picker.SelectedIndex;

            this.SelectedApi = index == -1 ? this.ApisDSte[0] : this.ApisDSte[index];
        }

        private async void LoadImageDSte(string url)
        {
            var stream = await WebStuffDSte.GetStreamDSte(url);
            this.AnimalDSte.Source = ImageSource.FromStream(() => stream);
        }
    }
}
