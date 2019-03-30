using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoApp.Domains
{
    public class CoinName
    {
        public CoinName(string name)
        {
            CryptoCoinName = name;
        }
        public string CryptoCoinName { get; set; }
    }
}
