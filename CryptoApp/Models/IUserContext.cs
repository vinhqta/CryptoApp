﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CryptoApp.Models
{
    public interface IUserContext
    {
        IMongoCollection<User> Users { get; }
    }
}
