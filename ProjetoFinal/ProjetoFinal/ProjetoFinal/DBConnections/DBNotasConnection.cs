using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.DBConnections
{
    public class DBNotasConnection
    {

        //Pull rows das Notas

        public async Task<string> PullRowNotas()
        {
            HttpClient _client = new HttpClient();
            const string Url = "https://projetopdm3.000webhostapp.com/pullRowNotas.php";




            var response = _client.GetAsync(Url).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else { return "Comunication Error"; }
        }

        //Pull das Notas
        public async Task<string> PullNotas(string id)
        {
            HttpClient _client = new HttpClient();
            const string Url = "https://projetopdm3.000webhostapp.com/pullNotas.php";

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


    }
}
