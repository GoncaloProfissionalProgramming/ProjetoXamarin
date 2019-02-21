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
	public partial class HorarioPage : ContentPage
	{
		public HorarioPage ()
		{
			InitializeComponent ();        
           
		}

       

        protected override async void OnAppearing()
        {
            Label[] coluna1 = { lblr1c1, lblr2c1,lblr3c1,lblr4c1,lblr5c1,lblr6c1,lblr7c1,lblr8c1,lblr9c1,lblr10c1 };
            Label[] coluna2 = { lblr1c2, lblr2c2, lblr3c2, lblr4c2, lblr5c2, lblr6c2, lblr7c2, lblr8c2, lblr9c2, lblr10c2 };
            Label[] coluna3 = { lblr1c3, lblr2c3, lblr3c3, lblr4c3, lblr5c3, lblr6c3, lblr7c3, lblr8c3, lblr9c3, lblr10c3 };
            Label[] coluna4 = { lblr1c4, lblr2c4, lblr3c4, lblr4c4, lblr5c4, lblr6c4, lblr7c4, lblr8c4, lblr9c4, lblr10c4 };
            Label[] coluna5 = { lblr1c5, lblr2c5, lblr3c5, lblr4c5, lblr5c5, lblr6c5, lblr7c5, lblr8c5, lblr9c5, lblr10c5 };
            Label[] coluna6 = { lblr1c6, lblr2c6, lblr3c6, lblr4c6, lblr5c6, lblr6c6, lblr7c6, lblr8c6, lblr9c6, lblr10c6 };
            Label[] coluna7 = { lblr1c7, lblr2c7, lblr3c7, lblr4c7, lblr5c7, lblr6c7, lblr7c7, lblr8c7, lblr9c7, lblr10c7 };
            Label[] coluna8 = { lblr1c8, lblr2c8, lblr3c8, lblr4c8, lblr5c8, lblr6c8, lblr7c8, lblr8c8, lblr9c8, lblr10c8 };
            Label[] coluna9 = { lblr1c9, lblr2c9, lblr3c9, lblr4c9, lblr5c9, lblr6c9, lblr7c9, lblr8c9, lblr9c9, lblr10c9 };
            Label[] coluna10 = { lblr1c10, lblr2c10, lblr3c10, lblr4c10, lblr5c10, lblr6c10, lblr7c10, lblr8c10, lblr9c10, lblr10c10 };

            Label[][] colunas = { coluna1, coluna2, coluna3, coluna4, coluna5, coluna6, coluna7, coluna8, coluna9, coluna10 };

            

            var turmaId = Variaveis.turmaId;
            for (int x = 0; x < Variaveis._rows; x++)
            {
                var horario = Variaveis._horario[x];
               
                if(horario.TurmaId == turmaId )
                {
                    int coluna = 0 ;
                    int colunaSala = 0 ;

                    switch (horario.DiaDaSemana) {
                        case "Segunda":
                            coluna = 0;
                            colunaSala = 1;
                            break;
                        case "Terça":
                            coluna = 2;
                            colunaSala = 3;
                            break;
                        case "Quarta":
                            coluna = 4;
                            colunaSala =5;
                            break;
                        case "Quinta":
                            coluna = 6;
                            colunaSala = 7;
                            break;
                        case "Sexta":
                            coluna = 8;
                            colunaSala = 9;
                            break;
                        

                    }

                   

                    int inicio = Int32.Parse(horario.Inicio);
                    int fim = Int32.Parse(horario.Fim);

                    int duração = fim - inicio;

                   
                    for(int y = 0;y < duração;y++)
                    {
                        int linha = inicio + y - 8;

                        colunas[coluna][linha].Text = horario.Disciplina;
                        colunas[colunaSala][linha].Text = horario.Sala;

                    }
                    



                }

               
            }
            base.OnAppearing();
        }

       
	}
}