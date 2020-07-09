using System.Data.Entity.Infrastructure.Interception;
using AutoLotDAL.Interception;

namespace AutoLotDAL.EF
{
    using System.Data.Entity;
    public partial class AutoLotEntities : DbContext
    {
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            DbInterception.Add(new ConsoleWriterInterceptor());
        }
        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
