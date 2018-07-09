using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using ScholarsTrip.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarsTrip.Data
{
    public class ScholarsTripSeeder
    {
        private readonly ScholarsTripDbContext context;
        private readonly IHostingEnvironment _hosting;

        public ScholarsTripSeeder(ScholarsTripDbContext context, IHostingEnvironment hostingEnvironment)
        {
            this.context = context;
            this._hosting = hostingEnvironment;
        }

        public void Seed()
        {
            context.Database.EnsureCreated();
            if (!context.Books.Any())
            {
                // Create sample data
                var path = Path.Combine(_hosting.ContentRootPath + "/Data/art.json");
                var json = File.ReadAllText(path);
                var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
                context.Books.AddRange(books);

                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = 1234,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Book = books.First(),
                            Quantity=5, 
                            UnitPrice = books.First().Price
                        }
                    }
                };

                context.Orders.Add(order);

                context.SaveChanges();
            }
        }

    }
}
