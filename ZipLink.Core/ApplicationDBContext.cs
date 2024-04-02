using Microsoft.EntityFrameworkCore;
using ZipLink.Core.Entities;

namespace ZipLink.Core
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt)
        {
            
        }

        public DbSet<Url> Urls => Set<Url>();
    }
}