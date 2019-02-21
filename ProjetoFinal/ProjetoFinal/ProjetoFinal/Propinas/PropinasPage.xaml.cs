using Newtonsoft.Json;
using ProjetoFinal.Classes;
using ProjetoFinal.DBConnections;
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
	public partial class PropinasPage : ContentPage
	{

        ObservableCollection<Propinas> Opropinas;

        public PropinasPage ()
		{
			InitializeComponent ();
		}



        private async void LoadPropinas()
        {
            DBPropinasConnection db = new DBPropinasConnection();

            Task<String> numberTask = db.PullRowPropinas();
            string number = await numberTask;

            Variaveis._rows3 = Int32.Parse(number);

            Variaveis._propinas = new Propinas[Variaveis._rows3];
            for (int id = 1; id <= Variaveis._rows3; id++)
            {
                String idString = id.ToString();
                Task<string> resultTask = db.PullPropinas(idString);
                string result = await resultTask;



                var propina = JsonConvert.DeserializeObject<Propinas>(result);

                Variaveis._propinas[id - 1] = propina;


               

            }
        }
       

        ObservableCollection<Propinas> GetPropinas()
        {
           return new ObservableCollection<Propinas>(Variaveis._propinas);
        }

        private void LView_Refreshing(object sender, EventArgs e)
        {
            LoadPropinas();
            Opropinas = GetPropinas();
            lView.ItemsSource = Opropinas;
            lView.EndRefresh();
        }

        private async void LView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var propinaSelecionada = e.SelectedItem as Propinas;
            String confirm = await DisplayActionSheet("Pagou a propina do mês de " + propinaSelecionada.Mes + "?", null, null, "Sim", "Não");
            if(confirm == "Sim")
            {
                DBPropinasConnection db = new DBPropinasConnection();
                propinaSelecionada.PagoN = "Propina Paga";
                Task<String> numberTask = db.UpdatePropina(propinaSelecionada.PagoN, propinaSelecionada.Id);
                LoadPropinas();
                Opropinas = GetPropinas();
                lView.ItemsSource = Opropinas;
                lView.EndRefresh();

            }
            if(confirm == "Não")
            {
                DBPropinasConnection db = new DBPropinasConnection();
                propinaSelecionada.PagoN = "Propina não paga";
                Task<String> numberTask = db.UpdatePropina(propinaSelecionada.PagoN, propinaSelecionada.Id);
                LoadPropinas();
                Opropinas = GetPropinas();
                lView.ItemsSource = Opropinas;
                lView.EndRefresh();
            }
        }
    }
}