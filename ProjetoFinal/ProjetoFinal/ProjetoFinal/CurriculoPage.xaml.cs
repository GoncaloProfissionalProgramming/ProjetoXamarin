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
	public partial class CurriculoPage : ContentPage
	{
		public CurriculoPage ()
		{
			InitializeComponent ();

            LoadCurriculo();

		}

        private async void LoadCurriculo()
        {
            DBConnection db = new DBConnection();


            String _id = Variaveis._aluno.Id;

            Task<string> resultTask = db.PullCurriculo(_id);
            string result = await resultTask;

            var curriculo = JsonConvert.DeserializeObject<Curriculo>(result);

            Variaveis._curriculo = curriculo;

            lbl_Username.Text = Variaveis._aluno.Username;
            lbl_Name.Text = Variaveis._aluno.Nome;
            lbl_email.Text = Variaveis._curriculo.Email;
            lbl_morada.Text = Variaveis._curriculo.Morada;
            lbl_Telemovel.Text = Variaveis._curriculo.Telemovel;

            //await DisplayAlert("Result", result, "OK");

        }

        protected override void OnAppearing()
        {
            LoadCurriculo();
            base.OnAppearing();
        }

        private async void Bt_EditPage_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new EditCurriculoPage());
        }
    }
}