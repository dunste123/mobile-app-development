using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShittyCSharpApp.Views.Tabs.Images
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AspectFillPage : ContentPage
	{
		public AspectFillPage ()
		{
			InitializeComponent ();

            this.Title = "AspectFill";

            this.ImageDSte.Source = ImageSource.FromResource("ShittyCSharpApp.Assets.Img.cat2.jpg");
            this.ImageDSte.Aspect = Aspect.AspectFill;
        }
	}
}