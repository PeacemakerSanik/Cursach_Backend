using Microsoft.EntityFrameworkCore;

namespace Cursach_Backend.Models
{
    public class Verified_IMSI_Context: DbContext
    {
        DbSet<IMSIModel> IMSITable { get; set; }

        public Verified_IMSI_Context(DbContextOptions options): base (options)
        {

        }
    }
}
