using ContactFormAndInformation.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactFormAndInformation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
        public DbSet<ContactInformation> Contact { get; set; }
        public DbSet<MailSettings> MailSettings { get; set; }
    }
}
