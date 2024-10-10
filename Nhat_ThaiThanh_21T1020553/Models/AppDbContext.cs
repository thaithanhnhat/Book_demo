using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nhat_ThaiThanh_21T1020553.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String conString = "Server=THANHNHAT\\SQLEXPRESS;Database=NhatThaiThanh21t1020553;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(conString);
        }
    }
}
