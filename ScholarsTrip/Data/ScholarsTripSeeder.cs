using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<StoreUser> userManager;

        public ScholarsTripSeeder(ScholarsTripDbContext context, IHostingEnvironment hostingEnvironment, UserManager<StoreUser> userManager)
        {
            this.context = context;
            this._hosting = hostingEnvironment;
            this.userManager = userManager;
        }

        public async Task Seed()
        {
            context.Database.EnsureCreated();

            var user = await userManager.FindByEmailAsync("katiaras15@gmail.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Kostas",
                    LastName = "Giouzakov",
                    UserName = "katiaras15",
                    Email = "katiaras15@gmail"
                };

                var result = await userManager.CreateAsync(user, "Kat!aras15");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create Default User");
                }
            }

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
                    OrderNumber = "1234",
                    User = user,
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
