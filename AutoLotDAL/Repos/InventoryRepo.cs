using System.Collections.Generic;
using System.Linq;
using AutoLotDAL.Models;

namespace AutoLotDAL.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>
    {
        /// <summary> Извлечение всех записей </summary>
        public new List<Inventory> GetAll() => Context.Inventories.OrderBy(x => x.Name).ToList();
    }
}
