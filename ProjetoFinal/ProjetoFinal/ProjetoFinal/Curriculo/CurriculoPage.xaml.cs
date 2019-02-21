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
	public partial class CurriculoPage : ContentPage
	{
		public CurriculoPage ()
		{
			InitializeComponent ();

            LoadCurriculo();

		}

        private async void LoadCurriculo()
        {
            DBCurriculoConnection db = new DBCurriculoConnection();


            String _id = Variaveis._aluno.Id;

            Task<string> resultTask = db.PullCurriculo(_id);
            string result = await resultTask;

            var curriculo = JsonConvert.DeserializeObject<Curriculo>(result);

            Variaveis._curriculo = curriculo;

            lbl_Username.Text = Variaveis._aluno.Username;
            lbl_Name.Text = Variaveis._aluno.Nome;

            if(curriculo.Email != null) { lbl_email.Text = Variaveis._curriculo.Email; }
            if (curriculo.Morada != null) { lbl_morada.Text = Variaveis._curriculo.Morada; }
            if (curriculo.Telemovel != null) { lbl_Telemovel.Text = Variaveis._curriculo.Telemovel; }
         
            
           

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