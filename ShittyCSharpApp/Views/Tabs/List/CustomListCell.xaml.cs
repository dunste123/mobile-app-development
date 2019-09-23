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
	public partial class CustomListCell : ViewCell
	{
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(CustomListCell), "Text");

        public CustomListCell ()
		{
			InitializeComponent ();
		}

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                TextLabelDSte.Text = Text;
            }
        }
    }
}