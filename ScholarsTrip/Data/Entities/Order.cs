using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarsTrip.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
