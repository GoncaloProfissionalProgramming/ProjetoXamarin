using ProjetoFinal.Classes;
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
            /*
            DBConnection db = new DBConnection();

            String turmaId = "2";

            String morada = "Morada";
            String telemovel = "Telemovel";
            String email = "Email";
            


            Task<string> resultTask = db.PullHorario(turmaId);
            string result = await resultTask;

           
                await DisplayAlert("Result", result, "OK");
            
            */

           

            await Navigation.PushModalAsync(new NavigationPage(new Login()));
        }

        private async void Bt_Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Register()));
        }
    }
}
