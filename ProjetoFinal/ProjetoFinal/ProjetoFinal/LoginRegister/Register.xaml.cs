using Newtonsoft.Json;
using ProjetoFinal.Classes;
using ProjetoFinal.DBConnections;
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
            
            DBLoginRegisterConnection db = new DBLoginRegisterConnection();
            DBCurriculoConnection db2 = new DBCurriculoConnection();

            String username = Et_Username.Text;
            String password = Et_Password.Text;
            String name = Et_Name.Text;


            String hashedPassword = Hash.sha256_hash(password);
            

            Task<string> resultTask = db.RegisterUser(name,username, hashedPassword);

            String result = await resultTask;


            



            
                var aluno = JsonConvert.DeserializeObject<Aluno>(result);

                Variaveis._aluno = aluno;


                Task<string> resultTask2 = db2.PostCurriculo(aluno.Id);

                

              
                await Navigation.PushModalAsync(new NavigationPage(new MenuPage()));
        

            

        }

	}
}