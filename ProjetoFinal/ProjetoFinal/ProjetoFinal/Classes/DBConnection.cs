using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Classes
{
    public class DBConnection
    {
        //Registro
        public async Task<string> RegisterUser(string nome, string username, string password)
        {

            HttpClient _client = new HttpClient();
            const string URL = "https://projetopdm3.000webhostapp.com/register.php";

            var values = new List<KeyValuePair<string, string>>
            {

                new KeyValuePair<string, string>("nome", nome),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)

            };

            var content = new FormUrlEncodedContent(values);
            var response = _client.PostAsync(URL, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }

            else
            {
                return "Communication Error";
            }

        }

        //Login
        public async Task<string> LoginUser(string username, string password)
        {
            HttpClient _client = new HttpClient();
            const string Url = "https://projetopdm3.000webhostapp.com/login.php";

            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            };

            var content = new FormUrlEncodedContent(values);
            var response = _client.PostAsync(Url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else { return "Comunication Error"; }
        }

        //Pull do Curriculo
        public async Task<string> PullCurriculo(string id)
        {
            HttpClient _client = new HttpClient();
            const string Url = "https://projetopdm3.000webhostapp.com/pullCurriculo.php";

            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("id", id)
            };

            var content = new FormUrlEncodedContent(values);
            var response = _client.PostAsync(Url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else { return "Comunication Error"; }
        }

        //Update do Curriculo
        public async Task<string> UpdateCurriculo(string telemovel,string morada,string email,string id)
        {
            HttpClient _client = new HttpClient();
            const string Url = "https://projetopdm3.000webhostapp.com/updateCurriculo.php";

            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("id", id),
                new KeyValuePair<string, string>("telemovel", telemovel),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("morada", morada)
            };

            var content = new FormUrlEncodedContent(values);
            var response = _client.PostAsync(Url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else { return "Comunication Error"; }
        }

        //Pull do Horario
        public async Task<string> PullHorario(string turmaId)
        {
            HttpClient _client = new HttpClient();
            const string Url = "https://projetopdm3.000webhostapp.com/pullHorario.php";

            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("turmaId", turmaId)
            };

            var content = new FormUrlEncodedContent(values);
            var response = _client.PostAsync(Url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else { return "Comunication Error"; }
        }




    }
}
