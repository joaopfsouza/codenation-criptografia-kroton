using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Utils;

namespace AnswerCodenation
{
    class AnswerRepository
    {
        HttpClient client = new HttpClient();
        public AnswerRepository()
        {
            

        }
        public AnswerRepository(string baseUri)
        {
            client.BaseAddress = new Uri(baseUri);
        }

        public async Task<TObject> GetGenerateDatatAsync<TObject>(string token){

            string resquestUri = "generate-data?token="+ token;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(resquestUri);

            if(response.IsSuccessStatusCode){
                //return await response.Content.ReadAsStringAsync();
               var data = await response.Content.ReadAsStringAsync();
               return JsonConvert.DeserializeObject<TObject>(data);
            }
            return default(TObject);
        }

    }
}
