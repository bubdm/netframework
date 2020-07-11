using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDAL.Models
{
    public partial class Person
    {
        public override string ToString()
        {
            return $"id: {Id} {Fam ?? "без фамилии"} {Name ?? "без имени"} {Age}";
        }
        [NotMapped]
        public string FullName => Fam + " " + Name;
    }
}
