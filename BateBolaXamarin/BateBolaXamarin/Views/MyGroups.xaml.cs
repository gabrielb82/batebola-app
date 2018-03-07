using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using BateBolaXamarin.Models;
using BateBolaXamarin.Connection;

namespace BateBolaXamarin.Views
{
    public partial class MyGroups : ContentPage
    {
        public List<Grupo> grupos;
        public bool isPublicGroupsSelected = false;
        public MyGroups()
        {
            InitializeComponent();

            ToolbarItems.Add(new ToolbarItem("Novo Grupo", "icon_new.png", async () => {
                await Navigation.PushAsync(new NewGroup());
            }));

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();



            GetMyGroups();

        }

        //MÉTODOS DE BUSCA DE GRUPOS
        void GetMyGroups()
        {
            isPublicGroupsSelected = false;
            grupos = CappriolaConnect.GetMyGroups();

            listViewGroups.ItemsSource = grupos;
        }

        void GetPublicGroups(string search = null)
        {
            isPublicGroupsSelected = true;
            grupos = CappriolaConnect.GetPublicGroups(search);

            listViewGroups.ItemsSource = grupos;
        }
        //*****************************


        //SELECIONAR GRUPOS QUE SERÃO APRESENTADOS (BOTÕES TOPO DA TELA)
        void MyProjectsClicked(object sender, System.EventArgs e)
        {
            //highlightBar.Margin = new Thickness(10,0,0,0);
            //SelectButton(sender as Button, publicGroupsButton);

            GetMyGroups();
        }

        void PublicProjectsClicked(object sender, System.EventArgs e)
        {
            //highlightBar.Margin = new Thickness(10,0,0,0);
            //SelectButton(sender as Button, myGroupsButton);

            GetPublicGroups();
        }

        void SelectButton(Button selectedButton, Button deSelectedButton) {
            selectedButton.BackgroundColor = Color.White;
            selectedButton.BorderColor = new Color(79, 169, 82, 1);
            selectedButton.TextColor = new Color(79, 169, 82, 1);



            //approvedImage.IsVisible = false;

            deSelectedButton.BackgroundColor = new Color(79, 169, 82, 1);
            deSelectedButton.BorderColor = new Color(79, 169, 82, 1);
            deSelectedButton.TextColor = Color.White;
        }
        //*****************************

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null)
            {
                // Yes, which one?
                if (e.OldTextValue.Length > 1)
                {
                    // Cancel has most probably been pressed
                    if(isPublicGroupsSelected) {
                        GetPublicGroups();
                    }
                    else {
                        listViewGroups.ItemsSource = grupos;
                    }
                }
                else
                {
                    // Backspace pressed on single character
                    // Cancel pressed on single character
                    var texto = groupsSearchBar.Text;
                    listViewGroups.ItemsSource = grupos.Where(
                        x => x.name.ToLower().Contains(texto.ToLower()));
                }
            }
            else {
                var texto = groupsSearchBar.Text;
                if(isPublicGroupsSelected) {
                    GetPublicGroups(texto);
                }
                else {
                    
                    listViewGroups.ItemsSource = grupos.Where(
                        x => x.name.ToLower().Contains(texto.ToLower()));
                }

            }


        }

        async void ItemSelected(object sender, ItemTappedEventArgs e)
        {
            
            Grupo group = (Grupo)e.Item;

            if(isPublicGroupsSelected) {
                ContentPage joinGroup = new JoinGroup(group.id);

                await Navigation.PushAsync(joinGroup);
            }
            else {
                ContentPage groupDetails = new GroupDetails(group);

                await Navigation.PushAsync(groupDetails);
            }

        }
    }
}
