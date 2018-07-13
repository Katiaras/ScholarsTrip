using Microsoft.EntityFrameworkCore;
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

        public void AddEntity(object model)
        {
            context.Add(model);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books
                .OrderBy(b => b.Price)
                .ToList();
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .OrderBy(o => o.OrderDate)
                .ToList();
            }
            else
            {
                return context.Orders
                    .OrderBy(o => o.OrderDate)
                    .ToList();
            }
            
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return context.Orders
                .Where(o=>o.User.UserName == username)
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .OrderBy(o => o.OrderDate)
                .ToList();
            }
            else
            {
                return context.Orders
                    .Where(o => o.User.UserName == username)
                    .OrderBy(o => o.OrderDate)
                    .ToList();
            }
        }

        public IEnumerable<Book> GetBookByCategory(string category)
        {
            return context.Books
                .Where(b => b.Category == category)
                .ToList();
        }

        public Order GetOrderById(string username, int id)
        {
            return context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .OrderBy(o => o.OrderDate)
                .Where(o=> o.Id == id && o.User.UserName == username)
                .FirstOrDefault();
        }

        public bool SaveAll()
        {
            context.SaveChanges();
            return true;

        }
    }
}
