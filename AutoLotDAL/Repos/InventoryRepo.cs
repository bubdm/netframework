using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.EF;

namespace AutoLotDAL.Repos
{
    class InventoryRepo : BaseRepo<Inventory>
    {
        /// <summary> Извлечение всех записей </summary>
        public new List<Inventory> GetAll() => Context.Inventories.OrderBy(x => x.Name).ToList();
    }
}
