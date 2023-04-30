using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AndreTurismoApp.Models.DTO;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class PostOfficesService
    {
        static readonly HttpClient address = new HttpClient();

        public async Task<ViaCepAddressDto> GetAddress(string zipCode)
        {
            try
            {
                HttpResponseMessage response = await PostOfficesService.address.GetAsync($"https://viacep.com.br/ws/{zipCode}/json/");
                response.EnsureSuccessStatusCode();
                string postOfficeJson = await response.Content.ReadAsStringAsync();
                var viaCepAddress = JsonConvert.DeserializeObject<ViaCepAddressDto>(postOfficeJson);
                return viaCepAddress;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
