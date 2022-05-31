using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            // in the var user we deserialize the list of users from AppUser and we pass in the userData
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            // In this step, the users should be a normal list of users of type AppUser
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                // We have the attributed UserName, PassHash, PassSalt,.... from the AppUser type (AppUsers.cs from Entities)
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}