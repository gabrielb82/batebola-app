using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BateBolaXamarin.Models;
using BateBolaXamarin.Connection;

namespace BateBolaXamarin.Views
{
    public partial class AllMyEvents : ContentPage
    {
        public AllMyEvents()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetAllMyEvents();
        }

        void GetAllMyEvents()
        {

            List<Events> events = CappriolaConnect.getAllMyEvents();

            BindingContext = events;
        }

        async void ViewEventParticipants(object sender, ItemTappedEventArgs e)
        {

            Events selectedEvent = (Events)e.Item;

            ContentPage eventParticipants = new EventParticipants(selectedEvent.id);

            await Navigation.PushAsync(eventParticipants);

        }
    }
}
