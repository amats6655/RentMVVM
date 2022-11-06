using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentMVVM.Model
{
    internal class Order
    {
        public int OrderId { get; set; }
        public User UserId { get; set; }
        public List<Equipment> Equipment { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime DateReturn { get; set; }

    }
}
