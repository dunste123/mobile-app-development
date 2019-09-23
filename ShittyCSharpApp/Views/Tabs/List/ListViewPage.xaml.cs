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
                new ImageDataSource { Text = "Hello", Detail = "World", Image = "https://d1q6f0aelx0por.cloudfront.net/product-logos/5431a80b-9ab9-486c-906a-e3d4b5ccaa96-hello-world.png" },
                new ImageDataSource { Text = "Tomatoes", Detail = "Color: Red", Image = "https://bonaprezo.awery.com/system/downloads/cake_product_file.php?file_id=578&thumb=1" }
            };

            ListCustomDSte.ItemsSource = new[] {
                new TextCell { Text = "Apple" },
                new TextCell { Text = "Pear" },
                new TextCell { Text = "Grape" }
            };
        }


        private class ImageDataSource
        {
            public string Image { get; set; }
            public string Text { get; set; }
            public string Detail { get; set; }
        }
    }
}