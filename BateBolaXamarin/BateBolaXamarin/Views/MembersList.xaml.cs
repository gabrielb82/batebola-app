using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BateBolaXamarin.Models;
using BateBolaXamarin.Connection;

namespace BateBolaXamarin.Views
{
    public partial class MembersList : ContentPage
    {
        public Grupo grupo;
        public MembersList(Grupo group)
        {
            InitializeComponent();

            BindingContext = group;
        }

        public async void ApproveUser(object sender, ItemTappedEventArgs e)
        {
            var action = await DisplayActionSheet("Opções", "Cancelar", "Remover do Grupo", "Dar Acesso ao Grupo");
            switch (action)
            {
                case "Dar Acesso ao Grupo":
                    
                    break;
                case "Remover do Grupo":
                    var confirm = await DisplayAlert("Remover Usuário", "Você deseja realmente remover o usuário do grupo?", "Sim", "Cancelar");
                    break;
                default:
                    break;
            }
        }
    }
}
