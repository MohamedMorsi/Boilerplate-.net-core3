using Microsoft.EntityFrameworkCore;
using Boilerplate.Models;

namespace Boilerplate.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt ):base(opt)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}