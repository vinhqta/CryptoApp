using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoApp.Models;

namespace CryptoApp.Services
{
    public interface ICoinServices
    {
        Task<CoinModel> GetCoin(string name);
    }
}
