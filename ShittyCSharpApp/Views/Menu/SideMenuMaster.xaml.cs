using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShittyCSharpApp.Views.Tabs.List;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShittyCSharpApp.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuMaster : ContentPage
    {
        public readonly ListView ListView;

        public SideMenuMaster()
        {
            InitializeComponent();

            BindingContext = new SideMenuMasterViewModel();
            ListView = MenuItemsListView;
        }

        private class SideMenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SideMenuMenuItem> MenuItems { get; set; }
            
            public SideMenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<SideMenuMenuItem>(new[]
                {
                    new SideMenuMenuItem { Id = 0, Title = "Color Mixer", TargetType = typeof(MainPage) },
                    new SideMenuMenuItem { Id = 1, Title = "Animals", TargetType = typeof(AnimalPage) },
                    new SideMenuMenuItem { Id = 2, Title = "Images'n stuff", TargetType = typeof(TabsPage) },
                    new SideMenuMenuItem { Id = 3, Title = "Grouped list", TargetType = typeof(ListGroupPageDSte) }
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}