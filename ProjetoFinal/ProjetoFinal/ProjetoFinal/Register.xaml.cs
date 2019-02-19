using Newtonsoft.Json;
using ProjetoFinal.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoFinal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
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


            String hashedPassword = Hash.sha256_hash(password);
            

            Task<string> resultTask = db.RegisterUser(name,username, hashedPassword);

            String result = await resultTask;

            

             Task<string> resultTask2 = db.LoginUser(username, hashedPassword);

            String result2 = await resultTask2;


            if (result2.Contains("success") && result2.Contains("true"))
            {
                var aluno = JsonConvert.DeserializeObject<Aluno>(result);

                Variaveis._aluno = aluno;



                await Navigation.PopAsync();

                await Navigation.PushModalAsync(new NavigationPage(new MenuPage()));
            }

            else
            {
                await DisplayAlert("Result", "Register Failed", "OK");
            }

            

        }

	}
}