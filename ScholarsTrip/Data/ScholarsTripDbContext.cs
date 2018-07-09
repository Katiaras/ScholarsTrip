using Microsoft.EntityFrameworkCore;
using ScholarsTrip.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarsTrip.Data
{
    public class ScholarsTripDbContext: DbContext
    {
        public ScholarsTripDbContext(DbContextOptions<ScholarsTripDbContext> options): base(options)
        {

        }

        public DbSet<Book> Books{ get; set; }
        public DbSet<Order> Orders{ get; set; }
    }
}
