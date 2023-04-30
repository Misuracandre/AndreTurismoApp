using System.Reflection.Emit;
using System.Text.Json.Serialization;
using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class CitiesService
    {
        static readonly HttpClient cityClient = new HttpClient();

        public async Task<List<City>> GetCity()
        {
            try
            {
                HttpResponseMessage response = await CitiesService.cityClient.GetAsync("https://localhost:7008/api/Cities");
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<City>>(city);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
