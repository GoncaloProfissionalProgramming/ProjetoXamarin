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
	public partial class EscolherTurmaExames : ContentPage
	{
		public EscolherTurmaExames ()
		{
			InitializeComponent ();
            LoadRows();
		}

        private async void LoadRows()
        {
            DBExamesConnection db = new DBExamesConnection();



            Task<string> resultTask = db.PullRowExames();
            string result = await resultTask;

            Variaveis._rows4 = Int32.Parse(result);
        }

        private async Task LoadExames()
        {
            DBExamesConnection db = new DBExamesConnection();

            Variaveis._exames = new Exames[Variaveis._rows4];

            for (int id = 1; id <= Variaveis._rows4; id++)
            {
                String idString = id.ToString();
                Task<string> resultTask = db.PullExames(idString);

                String result = await resultTask;

                if (result.Contains("success") && result.Contains("true"))
                {
                    var exame = JsonConvert.DeserializeObject<Exames>(result);


                    Variaveis._exames[id - 1] = exame;




                }

                else
                {
                    await DisplayAlert("Result", " Failed", "OK");
                }


            }
        }

        private async void TurmaA_Clicked(object sender, EventArgs e)
        {
            await LoadExames();

            Variaveis.turmaId = "2";
            
            await Navigation.PushAsync(new ExamesPage());
        }

        private async void TurmaB_Clicked(object sender, EventArgs e)
        {
            await LoadExames();

            Variaveis.turmaId = "1";

            await Navigation.PushAsync(new ExamesPage());
        }
    }
}