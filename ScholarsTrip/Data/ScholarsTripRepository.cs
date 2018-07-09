using ScholarsTrip.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarsTrip.Data
{
    public class ScholarsTripRepository : IScholarsTripRepository
    {
        private readonly ScholarsTripDbContext context;

        public ScholarsTripRepository(ScholarsTripDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books
                .OrderBy(b => b.Price)
                .ToList();
        }

        public IEnumerable<Book> GetBookByCategory(string category)
        {
            return context.Books
                .Where(b => b.Category == category)
                .ToList();
        }

    }
}
