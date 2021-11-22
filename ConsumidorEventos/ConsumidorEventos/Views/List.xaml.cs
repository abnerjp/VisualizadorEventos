using ConsumidorEventos.Domain.Model;
using ConsumidorEventos.Domain.Service;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsumidorEventos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class List : ContentPage
    {

        public List<Event> events;
        private FirebaseClient _firebase = FirebaseService.getConnection();

        public List()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            events = (await _firebase.Child("Events").OnceAsync<Event>())
                .Select(item => new Event
                {
                    EventName = item.Object.EventName,
                    DateTime = item.Object.DateTime,
                    Local = item.Object.Local,
                    Contact = item.Object.Contact,
                    Organization = item.Object.Organization,
                    Link = item.Object.Link
                }).ToList();

            EventsList.ItemsSource = events;
        }
    }
}