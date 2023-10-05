using Newtonsoft.Json;

namespace WEB_TTTN.Service
{
    public class Getapi<T> where T : class
    {
        public List<T> GetApi(string data)
        {
            var url = $"https://localhost:7150/api/";
            var httpClient = new HttpClient();
            var respones = httpClient.GetAsync(url + data).Result;
            var dataapi = respones.Content.ReadAsStringAsync().Result;
            var dataobj = JsonConvert.DeserializeObject<List<T>>(dataapi);
            return dataobj;           
        }
    }
}
