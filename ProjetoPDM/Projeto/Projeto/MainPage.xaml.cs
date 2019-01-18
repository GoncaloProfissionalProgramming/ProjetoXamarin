using Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projeto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Bt_Login_Clicked(object sender, EventArgs e)
        {

        }

        private async void Bt_Register_Clicked(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();

            Task<string> resultTask = db.RegisterUser("a", "b", "c");
            string result = await resultTask;

            await DisplayAlert("Result", result, "OK");
        }
    }
}
