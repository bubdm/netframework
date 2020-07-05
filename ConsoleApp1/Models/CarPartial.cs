using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EF
{
    public partial class Inventory
    {
        public override string ToString()
        {
            return $"{this.Name ?? "<без имени>"} цвета {this.Color} марки {this.Make} c Id {this.CarId}";
        }
    }
}
