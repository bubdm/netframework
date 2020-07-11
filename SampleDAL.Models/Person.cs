using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleDAL.Models.Base;

namespace SampleDAL.Models
{
    [Table("Person")]
    public partial class Person : BaseEntity
    {
        public Person() {}

        [StringLength(50)]
        public string Fam { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
        [ForeignKey(nameof(DepId))]
        public virtual Department Department { get; set; }
    }
}
