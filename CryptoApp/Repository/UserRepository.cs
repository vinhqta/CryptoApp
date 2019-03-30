using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoApp.Models;

using MongoDB.Bson;
using MongoDB.Driver;


namespace CryptoApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(User user)
        {
            await _context.Users.InsertOneAsync(user);
            return true;
        }

        public async Task<bool> Delete(string email)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(e => e.Email, email);
            DeleteResult deleteResult = await _context.Users.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public Task<User> GetUser(string email)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(e => e.Email, email);
            return _context.Users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Find(_ => true).ToListAsync();
        }

        public async Task<bool> Update(User user)
        {
            ReplaceOneResult updateResult = await _context.Users.ReplaceOneAsync(filter: u => u.Id == user.Id, replacement: user);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
