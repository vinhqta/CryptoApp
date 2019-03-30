using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CryptoApp.Services;
using CryptoApp.Domains;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoApp.Controllers
{
    [Route("coins")]
    public class CoinController : Controller
    {
        private readonly ICoinServices _coinServices;

        public CoinController(ICoinServices coinServices)
        {
            _coinServices = coinServices;
        }
        
        [HttpGet]
        [Route("listing/")]
        public async Task<IActionResult> GetCoinInfo([FromBody] CoinName name)
        {
            var result = await _coinServices.GetCoin(name.CryptoCoinName);

            return Ok(result);
        }

        [HttpGet]
        [Route("listing/coin")]
        public async Task<IActionResult> GetCoinInfo(string name)
        {
            var result = await _coinServices.GetCoin(name);
            return Ok(result);
        }
    }
}
