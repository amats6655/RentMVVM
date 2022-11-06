using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentMVVM.Model
{
    internal class Equipment
    {
        public int EqiopmentId { get; set; }
        public string Model { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }
        public List<Order> Orders { get; set; }
    }
}
