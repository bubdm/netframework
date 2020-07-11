using SampleDAL.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleDAL.Models
{
    [Table("Department")]
    public partial class Department : BaseEntity
    {
        public Department() {}
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Person> Persons { get; set; } = new HashSet<Person>();
    }
}
