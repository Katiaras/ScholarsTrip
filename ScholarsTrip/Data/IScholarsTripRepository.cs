using System.Collections.Generic;
using ScholarsTrip.Data.Entities;

namespace ScholarsTrip.Data
{
    public interface IScholarsTripRepository
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBookByCategory(string category);

        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(string username, int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}