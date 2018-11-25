using Microsoft.EntityFrameworkCore;

namespace FunWebApi.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

       

       public DbSet<Value> values {get;set;}
    }

}