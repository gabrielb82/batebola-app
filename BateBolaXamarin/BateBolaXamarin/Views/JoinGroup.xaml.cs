using System;
using System.Collections.Generic;
using System.Net;

using Xamarin.Forms;
using BateBolaXamarin.Models;
using BateBolaXamarin.Connection;

namespace BateBolaXamarin.Views
{
    public partial class JoinGroup : ContentPage
    {
        public int groupId;
        public Grupo grupo;
        public JoinGroup(int id)
        {
            InitializeComponent();

            grupo = CappriolaConnect.GetGroupDetails(id);

            BindingContext = grupo;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        async void HandleJoiningGroup(object sender, System.EventArgs e)
        {
            HttpStatusCode statusCode = CappriolaConnect.JoinGroupService(grupo.id);

            if(statusCode == HttpStatusCode.OK) {
                await DisplayAlert("Sucesso!", "Sua solicitação apra entrar no Grupo foi enviada com sucesso. Aguarde até que o criador do Grupo aprove sua entrada. Após aprovação você poderá fazer Check-In nos Eventos criados.", "OK");
                await Navigation.PopAsync();
            }
            else {
                await DisplayAlert("Oops.", "Algo errado aconteceu. Por favor, tente novamente.", "OK");
            }
        }

    }
}
