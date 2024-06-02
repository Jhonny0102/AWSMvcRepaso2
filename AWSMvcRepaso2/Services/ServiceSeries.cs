using AWSMvcRepaso2.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AWSMvcRepaso2.Services
{
    public class ServiceSeries
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceSeries(IConfiguration configuration)
        {
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiSeriesAWS");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            string request = "api/series";
            List<Serie> data = await this.CallApiAsync<List<Serie>>(request);
            return data;
        }

        public async Task<Serie> FinSerie(int idserie)
        {
            string request = "api/series/findserie/" + idserie;
            Serie data = await this.CallApiAsync<Serie>(request);
            return data;
        }

        public async Task CreateSerieAsync(Serie serie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/series";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string json = JsonConvert.SerializeObject(serie);
                StringContent content = new StringContent(json, this.header);
                HttpResponseMessage response = await client.PostAsync(this.UrlApi + request , content);
            }
        }

        public async Task UpdateSerieAsync(Serie serie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/series";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string json = JsonConvert.SerializeObject(serie);
                StringContent content = new StringContent(json, this.header);
                HttpResponseMessage response = await client.PutAsync(this.UrlApi + request , content);
            }
        }

        public async Task DeleteSerieAsync(int idserie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/series/delete/" + idserie;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.DeleteAsync(this.UrlApi + request);
            }
        }
    }
}
