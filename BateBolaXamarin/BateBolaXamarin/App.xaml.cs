using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using BateBolaXamarin.Views;

namespace BateBolaXamarin
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new BateBolaXamarin.MainPage();
		}

        public async static Task NavigateToProfile(string message)
        {

            //ContentPage nav = new ContentPage(new TabbedPage());

            //await Current.MainPage.Navigation.PushModalAsync(nav);

            await App.Current.MainPage.Navigation.PushModalAsync(new TabContainerPage());
        }

        public static Action HideLoginView
        {
            get
            {
                return new Action(() => App.Current.MainPage.Navigation.PopModalAsync());
            }
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
