using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace MasterApp.Pages
{
    public class RootPage : MasterDetailPage
    {
        MenuPage menuPage;

        public RootPage()
        {
            menuPage = new MenuPage();

            menuPage.Menu.ItemSelected += 
                (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

            Master = menuPage;

            Detail = new NavigationPage(new Home());
        }

        async void NavigateTo(MenuItem menu)
        {
            if (menu == null)
                return;

            

            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            try
            {
                Detail = new NavigationPage(displayPage);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERRO", "Erro "+ex.Message, "OK");
            }

            menuPage.Menu.SelectedItem = null;
            IsPresented = false;
        }
    }
}
