using ShittyCSharpApp.Views.Tabs.Images;
using ShittyCSharpApp.Views.Tabs.List;
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
	public partial class TabsPage : TabbedPage
    {
		public TabsPage ()
		{
            InitializeComponent();

            this.Title = "Images'n stuff";

            this.Children.Add(new ListViewPage());
            this.Children.Add(new AspectFitPage());
            this.Children.Add(new AspectFillPage());
            this.Children.Add(new FillPage());
        }
	}
}