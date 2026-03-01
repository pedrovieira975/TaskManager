using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface IUserRepository
    {
            Task<User?> GetUserByIdAsync(int userId);
            Task<User?> GetUserByEmailAsync(string email);
            Task CreateUserAsync(User user);
            Task UpdateUserAsync(User user);
            Task DeleteUserAsync(int userId);
    }
}