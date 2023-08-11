using Microsoft.EntityFrameworkCore;

namespace Test_C.EFCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<DrillBlock> DrillBlock { get; set; }
        public DbSet<DrillBlockPoints> DrillBlockPoints { get; set; }
        public DbSet<Hole> Hole { get; set; }
        public DbSet<HolePoints> HolePoints { get; set; }
    }
}
