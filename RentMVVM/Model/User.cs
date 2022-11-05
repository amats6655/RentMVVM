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
        public int id { get; set; }
        public string name { get; set; }
        public string Phone { get; set; }
        public bool debt { get; set; }  
        public Brush BgColor { get; set; }
        public string character { get; set; }
    }
}
