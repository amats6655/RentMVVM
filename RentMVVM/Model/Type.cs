using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentMVVM.Model
{
    internal class Type
    {
        public int TypeId { get; set; }
        public String TypeName { get; set; }
        public List<Equipment> Equipments { get; set; }
    }
}
