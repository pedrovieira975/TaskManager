using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task CreateUserAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new ArgumentException("User name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("User email cannot be empty.");
            }

            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with the same email already exists.");
            }

            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(user.Id) ?? throw new InvalidOperationException("User not found.");

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userId) ?? throw new InvalidOperationException("User not found.");

            await _userRepository.DeleteUserAsync(userId);
        }
    }
}