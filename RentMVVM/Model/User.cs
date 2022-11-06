using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RentMVVM.Model
{
    internal class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Debt { get; set; }  
        public Brush BgColor { get; set; }
        public string Character { get; set; }
        public Order OrderId { get; set; }
    }
}

