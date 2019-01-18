using Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto
{
	
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        private async void Bt_Login_Clicked(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();

            String username = Et_Username.Text;
            String password = Et_Password.Text;
           

            Task<string> resultTask = db.LoginUser(username, password);
            string result = await resultTask;

            if (result.Contains("success") && result.Contains("true"))
            {
                 await DisplayAlert("Result", result, "OK");
            }

            else
            {
                await DisplayAlert("Result", "Login Failed", "OK");
            }

        }
    }
}