using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EF
{
    public partial class Car
    {
        public override string ToString()
        {
            return $"{this.TopName ?? "<без имени>"} цвета {this.Color} марки {this.Make} c Id {this.CarId}";
        }
    }
}
