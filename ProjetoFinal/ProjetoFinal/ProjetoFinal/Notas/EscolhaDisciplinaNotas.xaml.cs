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
	public partial class EscolhaDisciplinaNotas : ContentPage
	{
		public EscolhaDisciplinaNotas ()
		{
			InitializeComponent ();
		}

        private async void PDMIII_Clicked(object sender, EventArgs e)
        {
            Variaveis.disciplina = "PDM III";

     
        

            await Navigation.PushAsync(new NotasPage());
        }

        private async void Projeto_Clicked(object sender, EventArgs e)
        {
            Variaveis.disciplina = "Projeto";
            await Navigation.PushAsync(new NotasPage());
        }
    }
}