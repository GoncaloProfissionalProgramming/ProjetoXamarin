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
	public partial class ExamesPage : ContentPage
	{
        ObservableCollection<Exames> Oexames;

		public ExamesPage ()
		{
			InitializeComponent ();
            
            Oexames = GetPropinas();
            lView.ItemsSource = Oexames;
        }

        ObservableCollection<Exames> GetPropinas()
        {
            var turmaId = Variaveis.turmaId;
            ObservableCollection<Exames> exames = new ObservableCollection<Exames>();
            for (int x = 0; x < Variaveis._rows4; x++)
            {
                if (Variaveis._exames[x].TurmaId == turmaId)
                {
                    var exame = Variaveis._exames[x];
                    exames.Add(exame);
                }
            }

                return exames;
        }

        private void LView_Refreshing(object sender, EventArgs e)
        {
            Oexames = GetPropinas();
            lView.ItemsSource = Oexames;
        }

     
    }
}