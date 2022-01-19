using Microsoft.EntityFrameworkCore;
using AgendaDemoBackend.Models;

namespace AgendaDemoBackend.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts => Set<Contact>();
    }
}
