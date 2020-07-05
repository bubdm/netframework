using System.ComponentModel.DataAnnotations;
using AutoLotDAL.Models.Base;

namespace AutoLotDAL.EF
{
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Order : EntityBase
    {
        //[Key]
        //public int OrderId { get; set; }

        public int CustId { get; set; }

        public int CarId { get; set; }
        [ForeignKey(nameof(CustId))]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(CarId))]
        public virtual Inventory Inventory { get; set; }
    }
}
