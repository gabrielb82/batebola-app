using System;
using System.Collections.Generic;
using System.Net;

using Xamarin.Forms;
using BateBolaXamarin.Models;
using BateBolaXamarin.Connection;

namespace BateBolaXamarin.Views
{
    public partial class EventParticipants : ContentPage
    {
        public Events evento;
        public EventParticipants(int eventId)
        {
            InitializeComponent();

            GetEventParticipants(eventId);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void GetEventParticipants(int eventId) {
            evento = CappriolaConnect.getEventParticipants(eventId);

            BindingContext = evento;
        }

        async void InformPayment(object sender, ItemTappedEventArgs e)
        {

            User user = (User)e.Item;

            if(user.paid == 0) {
                var askPayment = await DisplayAlert("Pagamento", "Confirmar pagamento?", "Sim", "Cancela");
                if(askPayment) {
                    HttpStatusCode statusCode = CappriolaConnect.ChanteEventPaymentStatusService(evento.id, user.id);

                    if(statusCode == HttpStatusCode.OK) {
                        await DisplayAlert("Sucesso!", "Pagamento informado com sucesso.", "OK");
                        GetEventParticipants(evento.id);
                    }
                    else if(statusCode == HttpStatusCode.Forbidden) {
                        await DisplayAlert("Erro!", "Apenas o criador do Grupo pode alterar as informações sobre o pagamento do evento.", "OK");
                    }
                    else {
                        await DisplayAlert("Erro!", "Não foi possível informar o pagamento. Por favor, tente novamente.", "OK");
                    }
                }
            }
            else {
                var askPayment = await DisplayAlert("Este usuário já efetuou o pagamento", "Gostaria de corrigir esta informação e marcar como não pago?", "Sim", "Cancela");
                if (askPayment)
                {
                    HttpStatusCode statusCode = CappriolaConnect.ChanteEventPaymentStatusService(evento.id, user.id);
                    if (statusCode == HttpStatusCode.OK)
                    {
                        await DisplayAlert("Sucesso!", "A informação sobre pagamento do membro do Grupo foi alterada com sucesso.", "OK");
                        GetEventParticipants(evento.id);
                    }
                    else if (statusCode == HttpStatusCode.Forbidden)
                    {
                        await DisplayAlert("Erro!", "Apenas o criador do Grupo pode alterar as informações sobre o pagamento do evento.", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Erro!", "Não foi possível alterar a informar sobre pagamento. Por favor, tente novamente.", "OK");
                    }
                }
            }



        }

        async void CheckIn(object sender, System.EventArgs e)
        {
            //highlightBar.Margin = new Thickness(10,0,0,0);
            //SelectButton(sender as Button, myGroupsButton);

            HttpStatusCode statusCode = CappriolaConnect.EventCheckInService(evento.id);

            if(statusCode == HttpStatusCode.Conflict) {
                await DisplayAlert("Não foi possível fazer seu check-in", "Você já está cadastrado neste evento.", "OK");
            }
            else if(statusCode == HttpStatusCode.OK) {
                await DisplayAlert("Sucesso!", "Você fez check-in no evento com sucesso.", "OK");
                GetEventParticipants(evento.id);
            }
            else {
                await DisplayAlert("Oops!", "Não foi possível fazer seu check-in no evento, algo estranho aconteceu. Tenta de novo, vai que dá!", "OK");
            }
        }
    }
}
