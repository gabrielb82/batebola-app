using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BateBolaXamarin.Connection;

namespace BateBolaXamarin
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();


		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Settings.Access_Token != "" && Settings.Access_Token != null)
            {
                if(Settings.FacebookID != null && Settings.FacebookID != "") {
                    if (CappriolaConnect.RetrieveAccessTokenFromFacebookLogin())
                    {
                        GoToApp();
                    }
                }

            }

        }

        private async void btnLogar_Clicked(object sender, EventArgs e)
        {
            NavigationPage nav = new NavigationPage(new Login() { Title = "Login" });
            NavigationPage.SetHasNavigationBar(nav, false);

            await Navigation.PushModalAsync(nav);

            //await Navigation.PushAsync(new Login());
        }

        public async void GoToApp(){
            await App.NavigateToProfile(string.Format("Olá Gabriel"));
        }
	}
}
