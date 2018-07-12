using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarsTrip.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int bookId { get; set; }

        public string bookCategory { get; set; }
        public decimal bookPrice { get; set; }
        public string bookTitle { get; set; }
        public DateTime bookDateReleased { get; set; }
        public string bookAuthor { get; set; }
        public string bookImageUrl { get; set; }
        public string bookDescription { get; set; }
        public int bookNumberOfPages { get; set; }
    }
}
