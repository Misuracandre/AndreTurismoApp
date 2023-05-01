﻿using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class CustomersService
    {
        static readonly HttpClient CustomerClient = new HttpClient();

        public async Task<List<Client>> GetCustomer()
        {
            try
            {
                HttpResponseMessage response = await CustomersService.CustomerClient.GetAsync("https://localhost:7239/api/Cities");
                response.EnsureSuccessStatusCode();
                string client = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Client>>(client);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}