using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShittyCSharpApp.Views.Tabs.List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListGroupPageDSte : ContentPage
    {
        private List<PersonList> _listOfPeople;
        public List<PersonList> ListOfPeople { 
            get => _listOfPeople;
            set { _listOfPeople = value; base.OnPropertyChanged(); }
        }

        public ListGroupPageDSte()
        {
            this.BindingContext = this;
            InitializeComponent();
            
            var sList = new PersonList
            {
                new Person { FirstName = "Sally", LastName = "Sampson" },
                new Person { FirstName = "Taylor", LastName = "Swift" },
                new Person { FirstName = "John", LastName = "Smith" }
            };
            sList.Heading = "S";

            var dList = new PersonList
            {
                new Person { FirstName = "Jane", LastName = "Doe" }
            };
            dList.Heading = "D";

            var jList = new PersonList
            {
                new Person { FirstName = "Billy", LastName = "Joel" }
            };
            jList.Heading = "J";

            var list = new List<PersonList>
            {
                sList,
                dList,
                jList
            };

            ListOfPeople = list;
        }

        public async void OnItemSelectedDSte(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            
            var person = (Person) e.SelectedItem;

            await DisplayAlert("You selected", person.DisplayName, "Ok");
            
            ((ListView) sender).SelectedItem = null;
        }
        
        public class PersonList : List<Person>
        {
            public string Heading { get; set; }
            public List<Person> Persons => this;
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DisplayName => $"{LastName}, {FirstName}";
        }
    }
}