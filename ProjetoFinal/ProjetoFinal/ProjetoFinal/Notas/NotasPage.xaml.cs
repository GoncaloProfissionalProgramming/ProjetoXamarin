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
	public partial class NotasPage : ContentPage
	{

        ObservableCollection<Notas> notas;

		public NotasPage ()
		{
			InitializeComponent ();

            Title = Variaveis.disciplina;
         
		}

        protected override void OnAppearing()
        {
            notas = GetNotas();
            lView.ItemsSource = notas;
            base.OnAppearing();
        }

        ObservableCollection<Notas> GetNotas()
        {
            var turmaId = Variaveis.turmaId;
            var disciplina = Variaveis.disciplina;
            ObservableCollection<Notas> notas = new ObservableCollection<Notas>();
            for (int x = 0; x < Variaveis._rows2; x++)
            {
                if (Variaveis._notas[x].TurmaId == turmaId && Variaveis._notas[x].Disciplina == disciplina)
                {
                    var nota = Variaveis._notas[x];
                    notas.Add(nota);
                }
            }

            return notas;
        }

      
    }
}