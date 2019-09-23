﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

            ApiDropdown.ItemsSource = apis;
            ApiDropdown.SelectedIndex = 0;

            ActivityDSte.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
            ActivityDSte.BindingContext = animal;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"https://apis.duncte123.me/animal/{selectedApi}");
            JObject obj = JObject.Parse(response);
            var imgUrl = (string)obj.SelectToken("data.file");

            Console.WriteLine(imgUrl);

            animal.Source = imgUrl;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
