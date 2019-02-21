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
	public partial class MenuPage : MasterDetailPage
	{
		public MenuPage ()
		{
            
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            lblNome.Text = Variaveis._aluno.Username;
            base.OnAppearing();
        }

        private void Curriculo_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CurriculoPage());
            this.IsPresented = false;
        }

        private void Horarios_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new EscolhaHorarioPage());
            this.IsPresented = false;
        }

        private void Notas_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new EscolhaTurmaNotas());
            this.IsPresented = false;
        }

        private void Propinas_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PropinasPage());
            this.IsPresented = false;
        }

        private void Exames_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new EscolherTurmaExames());
            this.IsPresented = false;
        }

        private async void Sair_Clicked(object sender, EventArgs e)
        {


            await Navigation.PopModalAsync();

            
           

        }


    }
}