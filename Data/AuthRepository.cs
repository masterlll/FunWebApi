using System;
using System.Threading.Tasks;
using FunWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FunWebApi.Data
{
    public class AuthRepository : IAuthRepository
    {

        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string Password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null) return null;
            if (!VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt)) return null;
            return user;
            //   throw new System.NotImplementedException();
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                int i = 0;
                while (i < ComputeHash.Length)
                {
                    if (ComputeHash[i] != passwordHash[i]) return false;
                    i++;
                }
                return true;
            }
            //   throw new NotImplementedException();
        }

        public async Task<User> Register(User user, string Password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await this._context.Users.AddAsync(user);
            await this._context.SaveChangesAsync();
            return user;
            //throw new System.NotImplementedException();
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

        public async Task<bool> UserExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username);
            //throw new System.NotImplementedException();
        }
    }
}