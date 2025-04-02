using Microsoft.EntityFrameworkCore;

namespace WEB_API_Database_Connection
{
    public class EmpdbContext:DbContext
    {
        public EmpdbContext(DbContextOptions<EmpdbContext> options) : base(options)
        {

        }
        public DbSet<Employe> Employe { get; set; }
    }
}
