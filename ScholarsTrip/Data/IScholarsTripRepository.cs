using System.Collections.Generic;
using ScholarsTrip.Data.Entities;

namespace ScholarsTrip.Data
{
    public interface IScholarsTripRepository
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBookByCategory(string category);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}