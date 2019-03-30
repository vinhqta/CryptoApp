using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoApp.Models;
using Newtonsoft.Json;

namespace CryptoApp.Services
{
    public class CoinServices : ICoinServices
    {
        private static readonly HttpClient Client = new HttpClient();
        public async Task<CoinModel> GetCoin(string name)
        {
            var url = new Uri($"https://api.coinmarketcap.com/v1/ticker/{name}");
            var response = await Client.GetAsync(url);
            string json;
            using (var content = response.Content)
            {
                
                json = await content.ReadAsStringAsync();

            }
            try
            {
                return JsonConvert.DeserializeObject<List<CoinModel>>(json)[0];
                
            }
            catch(Exception ex)
            {

                throw new JsonException();
            }
        }

    }
}

