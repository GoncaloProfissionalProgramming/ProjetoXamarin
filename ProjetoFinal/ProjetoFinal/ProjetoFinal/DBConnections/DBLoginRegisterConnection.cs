using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.DBConnections
{
    public class DBLoginRegisterConnection
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

       



    }
}
