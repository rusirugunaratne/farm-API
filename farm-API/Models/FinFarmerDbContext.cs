using Microsoft.EntityFrameworkCore;

namespace farm_API.Models
{
    public class FinFarmerDbContext:DbContext
    {
        public FinFarmerDbContext(DbContextOptions<FinFarmerDbContext> options) :base(options)
        {

        }

        public DbSet<Farm> Farms { get; set; }
        //public DbSet<UploadFile> Images { get; set; }

        public DbSet<Worker> Workers { get; set; }
    }
}
