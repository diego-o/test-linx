﻿using System;
using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Api.Services
{
    public static class PasswordService
    {
        private static readonly PasswordHasher<User> _passwordHasher = new();

        public static string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public static bool VerifyPassword(User user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }

    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
