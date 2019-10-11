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
	public partial class CustomListCellDSte : ViewCell
	{
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(CustomListCellDSte), "Text");

        public CustomListCellDSte   ()
		{
			InitializeComponent ();
		}

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
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