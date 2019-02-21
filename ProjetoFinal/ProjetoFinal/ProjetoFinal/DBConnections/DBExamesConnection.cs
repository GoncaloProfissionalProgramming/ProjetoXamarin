using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.DBConnections
{
    class DBExamesConnection
    {
        //Pull rows dos Exames

        public async Task<string> PullRowExames()
        {
            HttpClient _client = new HttpClient();
            const string Url = "https://projetopdm3.000webhostapp.com/pullRowExames.php";

            var response = _client.GetAsync(Url).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else { return "Comunication Error"; }
        }

        //Pull dos Exames
        public async Task<string> PullExames(string id)
        {
            HttpClient _client = new HttpClient();
            const string Url = "https://projetopdm3.000webhostapp.com/pullExames.php";

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
