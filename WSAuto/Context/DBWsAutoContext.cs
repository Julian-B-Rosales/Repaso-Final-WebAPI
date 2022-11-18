using Microsoft.EntityFrameworkCore;
using WSAuto.Models;

namespace WSAuto.Context
{
    public partial class DBWsAutoContext : DbContext
    {
        public DBWsAutoContext()
        {
        }

        public DBWsAutoContext(DbContextOptions<DBWsAutoContext> options) : base(options)
        {
        }


        public DbSet<Auto> Autos { get; set; }
    }
}
