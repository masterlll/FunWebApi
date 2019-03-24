using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FunWebApi.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;

        public DatingRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {

            _context.Add(entity);
            // throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {

            _context.Remove(entity);
            //throw new System.NotImplementedException();
        }

        public async  Task<Photo> GetMainPhotoForUser(int userid)
        {
           
           return await _context.Photos.Where(x=>x.UserId == userid).FirstOrDefaultAsync(x=>x.IsMain);
        }

        public async  Task<Photo> GetPhoto(int id)
        {

            var Photo = await _context.Photos.FirstOrDefaultAsync(a =>a.Id == id);
            return  Photo;
       
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(x => x.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;

            // throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(x => x.Photos).ToListAsync();
            return users;
            // throw new System.NotImplementedException();
        }

        public async Task<bool> SaveAll()
        {

            return await _context.SaveChangesAsync() > 0;
            // throw new System.NotImplementedException();
        }
    }
}