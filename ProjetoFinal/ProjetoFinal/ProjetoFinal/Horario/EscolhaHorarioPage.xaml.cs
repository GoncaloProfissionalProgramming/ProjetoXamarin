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
	public partial class EscolhaHorarioPage : ContentPage
	{
		public EscolhaHorarioPage ()
		{
			InitializeComponent ();
            LoadRows();
		}

        private async void LoadRows()
        {
            DBHorarioConnection db = new DBHorarioConnection();



            Task<string> resultTask = db.PullRowHorario();
            string result = await resultTask;

            Variaveis._rows = Int32.Parse(result);
        }

        private async Task LoadHorarios()
        {
            DBHorarioConnection db = new DBHorarioConnection();

            Variaveis._horario = new Horario[Variaveis._rows];

            for (int id = 1; id <= Variaveis._rows; id++)
            {
                String idString = id.ToString();
                Task<string> resultTask = db.PullHorario(idString);

                String result = await resultTask;

                if (result.Contains("success") && result.Contains("true"))
                {
                    var horario = JsonConvert.DeserializeObject<Horario>(result);


                    Variaveis._horario[id - 1] = horario;



                  
                }

                else
                {
                    await DisplayAlert("Result", " Failed", "OK");
                }

                
            }
        }

        private async void TurmaB_Clicked(object sender, EventArgs e)
        {
            await LoadHorarios();

            Variaveis.turmaId = "1";

            await Navigation.PushAsync(new HorarioPage());
        }

        private async void TurmaA_Clicked(object sender, EventArgs e)
        {
            await LoadHorarios();

            Variaveis.turmaId = "2";

            await Navigation.PushAsync(new HorarioPage());
        }
    }
}