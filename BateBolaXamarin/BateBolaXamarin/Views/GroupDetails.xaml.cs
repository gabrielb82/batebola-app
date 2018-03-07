using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BateBolaXamarin.Models;
using BateBolaXamarin.Connection;

namespace BateBolaXamarin.Views
{
    public partial class GroupDetails : ContentPage
    {
        public Grupo grupo;
        public bool is_member;
        public GroupDetails(Grupo selectedGroup)
        {
            InitializeComponent();

            is_member = selectedGroup.approved == 0 ? false : true;

            grupo = CappriolaConnect.GetGroupDetails(selectedGroup.id);

            if (is_member)
            {
                ToolbarItems.Add(new ToolbarItem("Novo Grupo", "icon_users.png", async () => {
                    await Navigation.PushAsync(new MembersList(grupo));
                }));
            }
            else {
                newEventButton.IsEnabled = false;
            }


        }

        void GetGroupDetails() {
            BindingContext = grupo;

            if(!is_member) {
                nextEventsLabel.Text = "  Aguardando aprovação.";
            }
            else {
                if (grupo.events.Count == 0)
                {
                    nextEventsLabel.Text = "  Sem Eventos agendados...";
                }
                else
                {
                    nextEventsLabel.Text = "  Próximos Eventos";
                }
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetGroupDetails();
        }

        async void ViewEventParticipants(object sender, ItemTappedEventArgs e)
        {

            Events selectedEvent = (Events)e.Item;

            ContentPage eventParticipants = new EventParticipants(selectedEvent.id);

            await Navigation.PushAsync(eventParticipants);

        }

        async void NewEvent(object sender, System.EventArgs e) {
            
            ContentPage newEvent = new NewEvent(grupo.id);

            await Navigation.PushAsync(newEvent);
        }
    }
}
