using System.Data.Entity.Infrastructure.Interception;
using AutoLotDAL.Interception;

namespace AutoLotDAL.EF
{
    using AutoLotDAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;

    public partial class AutoLotEntities : DbContext
    {
        static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt", true);
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            //DbInterception.Add(new ConsoleWriterInterceptor());
            //DatabaseLogger.StartLogging();
            //DbInterception.Add(DatabaseLogger);
            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;
        }
        private void OnSavingChanges(object sender, EventArgs eventArgs)
        { //текущие, исходные значения, можно отменять/модифицировать операции сохранения любым способом
            var context = sender as ObjectContext;
            if (context == null) return;
            foreach (var item in context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added))
            { //добавленные или измененнные
                if ((item.Entity as Inventory) != null)
                {
                    var entity = (Inventory)item.Entity;
                    if (entity.Name == "NewName")
                    { //отклоняет все изменения названий в Запорожец
                        item.RejectPropertyChanges(nameof(entity.Name));
                    }
                }
            }
        }
        private void OnObjectMaterialized(object sender, System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        { //полезно при работе с WPF
        }



        protected override void Dispose(bool disposing)
        {
            //DbInterception.Remove(DatabaseLogger);
            //DatabaseLogger.StopLogging();
            base.Dispose(disposing);
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
