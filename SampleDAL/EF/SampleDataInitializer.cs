using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDAL.Models;

namespace SampleDAL.EF
{
    public class SampleDataInitializer : DropCreateDatabaseAlways<SampleEntities>
    {
        protected override void Seed(SampleEntities context)
        {
            var departments = new List<Department>
            {
                new Department {Name = "Отдел быта"},
                new Department {Name = "Отдел счастья"},
                new Department {Name = "Отдел здоровья"},
            };
            departments.ForEach(x => context.Departments.AddOrUpdate(d => new {d.Name}, x));
            var persons = new List<Person>
            {
                new Person {Fam = "Петров", Name = "Петя", Age = 18, Department = departments[0]},
                new Person {Fam = "Иванов", Name = "Иван", Age = 28, Department = departments[1]},
                new Person {Fam = "Сидоров", Name = "Сидор", Age = 24, Department = departments[1]},
                new Person {Fam = "Макаров", Name = "Макар", Age = 20, Department = departments[2]},
                new Person {Fam = "Федотов", Name = "Федот", Age = 19, Department = departments[2]},
                new Person {Fam = "Героев", Name = "Гер", Age = 21, Department = departments[2]},
            };
            persons.ForEach(x => context.Persons.AddOrUpdate(p => new {p.Fam, p.Name, p.Age, p.DepId}, x));
        }
    }
}
