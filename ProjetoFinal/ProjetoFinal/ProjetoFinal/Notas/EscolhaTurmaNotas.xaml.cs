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
	public partial class EscolhaTurmaNotas : ContentPage
	{
		public EscolhaTurmaNotas ()
		{
			InitializeComponent ();
            LoadRows();
		}
        private async void LoadRows()
        {
            DBNotasConnection db = new DBNotasConnection();



            Task<string> resultTask = db.PullRowNotas();
            string result = await resultTask;

            Variaveis._rows2 = Int32.Parse(result);
        }

        private async Task LoadNotas()
        {
            DBNotasConnection db = new DBNotasConnection();

            Variaveis._notas = new Notas[Variaveis._rows2];

            for (int id = 1; id <= Variaveis._rows2; id++)
            {
                String idString = id.ToString();
                Task<string> resultTask = db.PullNotas(idString);

                String result = await resultTask;

                if (result.Contains("success") && result.Contains("true"))
                {
                    var nota = JsonConvert.DeserializeObject<Notas>(result);


                    Variaveis._notas[id - 1] = nota;




                }

                else
                {
                    await DisplayAlert("Result", " Failed", "OK");
                }


            }
        }

        private async void TurmaA_Clicked(object sender, EventArgs e)
        {
            await LoadNotas();

            Variaveis.turmaId = "2";

            await Navigation.PushAsync(new EscolhaDisciplinaNotas());
        }

        private async void TurmaB_Clicked(object sender, EventArgs e)
        {
            await LoadNotas();

            Variaveis.turmaId = "1";

            await Navigation.PushAsync(new EscolhaDisciplinaNotas());
        }
    }
}