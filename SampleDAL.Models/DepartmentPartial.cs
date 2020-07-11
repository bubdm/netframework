using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDAL.Models
{
    public partial class Department
    {
        public override string ToString()
        {
            return $"Название отдела: {Name ?? "без имени"}";
        }
    }
}
