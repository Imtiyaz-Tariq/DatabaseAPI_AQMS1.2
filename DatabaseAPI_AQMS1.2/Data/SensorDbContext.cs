using DatabaseAPI_AQMS1._2.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI_AQMS1._2.Data
{
    public class SensorDbContext : DbContext
    {
        public SensorDbContext(DbContextOptions<SensorDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Sensor> Sensors { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:sensorsdbserver.database.windows.net,1433;Initial Catalog=SensorsDb;Persist Security Info=False;User ID=Imtiyaz.Tariq;Password=Immit@13;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
