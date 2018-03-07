using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BateBolaXamarin.Views
{
    public partial class TabContainerPage : TabbedPage
    {
        public TabContainerPage()
        {
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //var groupsPage = new NavigationPage(new MyGroups());
            //groupsPage.Icon = "icon_group.png";
            //groupsPage.Title = "Grupos";

            //var eventsPage = new NavigationPage(new EventsList());
            //eventsPage.Icon = "icon_ball.png";
            //eventsPage.Title = "Eventos";

            //Children.Add(groupsPage);
            //Children.Add(eventsPage);
        }
    }
}
