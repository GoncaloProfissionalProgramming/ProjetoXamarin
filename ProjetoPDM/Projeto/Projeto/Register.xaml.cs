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
	public partial class Register : ContentPage
	{
		public Register ()
		{
			InitializeComponent ();
		}

        private async void Bt_Register_Clicked(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();

            String username = Et_Username.Text;
            String password = Et_Password.Text;
            String name = Et_Name.Text;

            Task<string> resultTask = db.RegisterUser(name,username, password);
            string result = await resultTask;

            await DisplayAlert("Result", result, "OK");
        }

       
    }
}