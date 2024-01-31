using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace WebAPIDemo.Models
{
    public class WebAPIDemoContext : DbContext
    {
        public WebAPIDemoContext(DbContextOptions<WebAPIDemoContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
