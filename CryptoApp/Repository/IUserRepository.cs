using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoApp.Models;

namespace CryptoApp.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string email);
        Task<bool> Create(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(string email);
    }
}
