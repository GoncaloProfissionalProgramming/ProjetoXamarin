using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoFinal.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoFinal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
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

            String hashedPassword = Hash.sha256_hash(password);


            Task<string> resultTask = db.LoginUser(username, hashedPassword);
            string result = await resultTask;

            if (result.Contains("success") && result.Contains("true"))
            {
                var aluno = JsonConvert.DeserializeObject<Aluno>(result);

                Variaveis._aluno = aluno;

           
          
                 await Navigation.PopAsync();

                await Navigation.PushModalAsync(new NavigationPage(new MenuPage()));
            }

            else
            {
                await DisplayAlert("Result", "Login Failed", "OK");
            }

        }
    }
}