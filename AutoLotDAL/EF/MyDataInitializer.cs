using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace AutoLotDAL.EF
{
    public class MyDataInitializer : DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            var customers = new List<Customer>
            {
                new Customer {FirstName = "Dave", LastName = "Brenner"},
                new Customer {FirstName = "Matt", LastName = "Walton"},
                new Customer {FirstName = "Steve", LastName = "Hagen"},
                new Customer {FirstName = "Pat", LastName = "Walton"},
                new Customer {FirstName = "Badd", LastName = "Customer"},
            };
            customers.ForEach(x => context.Customers.AddOrUpdate(c => new {c.FirstName, c.LastName}, x));
            var cars = new List<Inventory>
            {
                new Inventory {Make = "VW", Color = "Black", Name = "Zippy"},
                new Inventory {Make = "Ford", Color = "Rust", Name = "Rusty"},
                new Inventory {Make = "Saab", Color = "Yellow", Name = "Mel"},
                new Inventory {Make = "Yugo", Color = "Black", Name = "Bimmer"},
                new Inventory {Make = "BMW", Color = "Green", Name = "Hawk"},
                new Inventory {Make = "BMW", Color = "Pink", Name = "Hank"},
                new Inventory {Make = "BMW", Color = "Brown", Name = "Pete"},
                new Inventory {Make = "Pinto", Color = "Black", Name = "Zippy"},
            };
            context.Inventories.AddOrUpdate(x => new {x.Make, x.Color}, cars.ToArray());
            var orders = new List<Order>
            {
                new Order { Inventory = cars[0], Customer = customers[0]},
                new Order { Inventory = cars[1], Customer = customers[1]},
                new Order {Inventory = cars[2], Customer = customers[2]},
                new Order {Inventory = cars[3], Customer = customers[3]},
            };
            orders.ForEach(x => context.Orders.AddOrUpdate(c => new {c.CarId, c.CustId}, x));
            context.CreditRisks.AddOrUpdate(x => new { x.FirstName, x.LastName },
                new CreditRisk
                {
                    Id = customers[4].Id,
                    FirstName = customers[4].FirstName,
                    LastName = customers[4].LastName,
                });
        }
    }
}
