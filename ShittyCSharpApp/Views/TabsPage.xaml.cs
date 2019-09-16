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

            this.Title = "TabbedPage";

            this.Children.Add(new MainPage());
            this.Children.Add(new AnimalPage());
        }
	}
}