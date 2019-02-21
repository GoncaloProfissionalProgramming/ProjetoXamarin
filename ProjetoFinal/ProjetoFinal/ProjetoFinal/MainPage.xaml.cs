using Newtonsoft.Json;
using ProjetoFinal.Classes;
using ProjetoFinal.DBConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoFinal
{

    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        
        private async void Bt_Login_Clicked(object sender, EventArgs e)
        {

          
            await Navigation.PushModalAsync(new NavigationPage(new Login()));
        }

        private async void Bt_Register_Clicked(object sender, EventArgs e)
        {
           
            await Navigation.PushModalAsync(new NavigationPage(new Register()));
        }
    }
}
