using System.Data.Entity;
using SampleDAL.Models;

namespace SampleDAL.EF
{
    public partial class SampleEntities : DbContext
    {
        public SampleEntities() : base("name=SampleConnection")
        {
        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
