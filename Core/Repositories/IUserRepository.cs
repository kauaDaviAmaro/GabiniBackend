﻿using Core.Models;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        public Task<User> SaveUser(User user);
    }
}
