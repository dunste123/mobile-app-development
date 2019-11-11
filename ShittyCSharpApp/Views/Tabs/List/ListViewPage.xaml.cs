using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShittyCSharpApp.Views.Tabs.List
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
        public ListViewPage()
        {
            InitializeComponent();

            this.Title = "Lists";

            ListImagesDSte.ItemsSource = new[] {
                new ImageDataSourceDSte { Text = "Hello", Detail = "World", Image = "https://placekitten.com/g/400/400" },
                new ImageDataSourceDSte { Text = "Tomatoes", Detail = "Color: Red", Image = "https://placekitten.com/400/400?image=4" }
            };

            ListCustomDSte.ItemsSource = new[] {
                new TextCell { Text = "Apple" },
                new TextCell { Text = "Pear" },
                new TextCell { Text = "Grape" }
            };
        }


        private class ImageDataSourceDSte
        {
            public string Image { get; set; }

            public ImageSource ImageSource
            {
                get => ImageSource.FromStream(() => WebStuffDSte.GetStreamSyncDSte(this.Image));
                set {}
            }

            public string Text { get; set; }
            public string Detail { get; set; }
        }
    }
}