using System.Collections.Generic;
using System.IO;
using FunWebApi.Models;
using Newtonsoft.Json;

namespace FunWebApi.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;

        }

        public void SeedUsers()
        {

            var userData = File.ReadAllText("Data/UserSeedData.json");

            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            foreach (var p in users)
            {
                byte[] passwordHash, passwordSalt;

                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                p.PasswordHash = passwordHash;
                p.PasswordSalt = passwordSalt;
                //  p.Username =p.Username.ToLower(); 
                _context.Users.Add(p);

            }
            _context.SaveChanges();

        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            //throw new NotImplementedException();
        }

    }
}