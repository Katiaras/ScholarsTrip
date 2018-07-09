using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarsTrip.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
    }
}
