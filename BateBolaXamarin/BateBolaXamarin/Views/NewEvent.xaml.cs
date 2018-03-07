using System;
using System.Collections.Generic;
using System.Net;

using Xamarin.Forms;
using BateBolaXamarin.Models;
using BateBolaXamarin.Connection;

namespace BateBolaXamarin.Views
{
    public partial class NewEvent : ContentPage
    {
        public Grupo grupo;
        public NewEvent(int groupId)
        {
            InitializeComponent();
            grupo = new Grupo();
            grupo.id = groupId;
        }

        async void CreateEvent(object sender, System.EventArgs e) {
            string eventDate = event_year.Text + "-" + event_month.Text + "-" + event_day.Text + " " + event_hour.Text + ":" + event_minute.Text + ":00";

            HttpStatusCode statusCode = CappriolaConnect.CreateEventService(grupo.id, event_place.Text, eventDate);

            if(statusCode == HttpStatusCode.OK) {
                await DisplayAlert("Sucesso!", "Evento criado com sucesso.", "OK");
                await Navigation.PopAsync();
            }
            else {
                await DisplayAlert("Oops!", "Não foi possíve criar seu evento. Por favor, tente novamente.", "OK");
            }
        }
    }
}
