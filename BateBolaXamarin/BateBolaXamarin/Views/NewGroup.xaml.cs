using System;
using System.Net;
using System.Collections.Generic;

using Xamarin.Forms;
using BateBolaXamarin.Connection;
using System.Threading.Tasks;

namespace BateBolaXamarin.Views
{
    public partial class NewGroup : ContentPage
    {
        public NewGroup()
        {
            InitializeComponent();
        }

        public async void CreateGroup(object sender, System.EventArgs e)
        {
            HttpStatusCode statusCode = CappriolaConnect.CreateGroupService(groupName.Text);

            if(statusCode == HttpStatusCode.OK) {
                await ShowMessage("Grupo criado com sucesso", "Bate Bola", "Ok", async () =>
                {
                    await Navigation.PopAsync();
                });
            }
            else {
                await DisplayAlert("Bate Bola", "Erro ao criar Grupo. Por favor, tente novamente", "OK");
            }
        }

        public async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            await DisplayAlert(title, message, buttonText);

            afterHideCallback?.Invoke();
        }

    }
}
