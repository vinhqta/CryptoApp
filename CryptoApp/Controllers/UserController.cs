using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CryptoApp.Models;
using CryptoApp.Services;
using CryptoApp.Repository;

namespace CryptoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //private readonly UserService _service;
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/user")]
        public IActionResult User()
        {
            return View();
        }

        [Route("/home")]
        public IActionResult Home()
        {
            return View();
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _repo.GetUsers());
        }

        // GET: api/user/email
        [HttpGet("{email}", Name = "Get")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _repo.GetUser(email);
            if (user == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(user);
        }

        // POST: api/user
        [HttpPost]
        public  ActionResult Post([FromBody]User user)
        {
            _repo.Create(user);
            return RedirectToAction("Index", "Home");
        }

        // PUT: api/user/#
        [HttpPut("{email}")]
        public async Task<IActionResult> Put(string email, [FromBody]User user)
        {
            var userFromDb = await _repo.GetUser(email);
            if (userFromDb == null)
            {
                return new NotFoundResult();
            }
            user.Id = userFromDb.Id;

            await _repo.Update(user);

            return new OkObjectResult(user);
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            var userFromDb = await _repo.GetUser(email);
            if (userFromDb == null)
            {
                return new NotFoundResult();
            }

            await _repo.Delete(email);

            return new OkResult();
        }


    }
}
