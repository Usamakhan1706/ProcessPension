using Microsoft.EntityFrameworkCore;
using ProcessPensionModule.Models;

namespace ProcessPensionModule.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<PensionerDetail> PensionerDetails { get; set; }
        public object Users { get; set; }
    }
}
