﻿using ProjetoFinal.Classes;
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
	public partial class EditCurriculoPage : ContentPage
	{
		public EditCurriculoPage ()
		{
			InitializeComponent ();
            Et_Telemovel.Text = Variaveis._curriculo.Telemovel;
            Et_Morada.Text = Variaveis._curriculo.Morada;
            Et_email.Text = Variaveis._curriculo.Email;
        }

        private async void Bt_Edit_Clicked(object sender, EventArgs e)
        {

            String morada = Et_Morada.Text;
            String telemovel = Et_Telemovel.Text;
            String email = Et_email.Text;

            if (morada == "")
            {
                morada = Variaveis._curriculo.Morada;
            }

            if(telemovel == "")
            {
                telemovel = Variaveis._curriculo.Telemovel;
            }

            if(email == "")
            {
                email = Variaveis._curriculo.Email;
            }

            DBConnection db = new DBConnection();
            String _id = Variaveis._aluno.Id;

            Task<string> resultTask = db.UpdateCurriculo(telemovel,morada,email,_id);


            
            await Navigation.PopAsync();
            
         
        }
    }
}