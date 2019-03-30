using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoApp.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CryptoApp.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("UserDb"));
            var database = client.GetDatabase("UserDb");
            _users = database.GetCollection<User>("User");
        }

        public async Task<List<User>> GetUsers()
        {
            return await _users.Find(user => true).ToListAsync();
        }

        public async Task<User> GetUser(string email)
        {
            return await _users.Find(user => user.Email == email).FirstOrDefaultAsync();
        }

        public async Task AddUser(User user)
        {
            await _users.InsertOneAsync(user);
        }

        public async Task Update(string email, User updatedUser)
        {
            await _users.ReplaceOneAsync(user => user.Email == email, updatedUser);
        }

        public async Task Remove(string email)
        {
            await _users.DeleteOneAsync(user => user.Email == email);
        }

    }

}
