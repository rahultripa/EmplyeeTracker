using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TrackEmployees.RestClient
{

    public class ServerResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class RestClient<T>
    {
     
        public async Task<List<T>> GetAsync(string url)
        {
            var httpClient = new HttpClient();
            try
            {
                var json = await httpClient.GetStringAsync(url);

                var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
              
                return taskModels;
            }
            catch (Exception ex)
            {
            }
            return null;


        }

        public async Task<T> PostAsync(T t, string url)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);
           
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(url, httpContent);
            var responseString = await result.Content.ReadAsStringAsync();
            var taskModels = JsonConvert.DeserializeObject<T>(responseString);

            return taskModels;
        }

        public async Task<bool> PutAsync(T t, string url)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
          

            var result = await httpClient.PutAsync(url, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t, string url)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url + id);
          
            return response.IsSuccessStatusCode;
        }
    }
}
