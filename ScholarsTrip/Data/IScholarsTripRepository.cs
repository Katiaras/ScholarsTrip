using System.Collections.Generic;
using ScholarsTrip.Data.Entities;

namespace ScholarsTrip.Data
{
    public interface IScholarsTripRepository
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBookByCategory(string category);
    }
}