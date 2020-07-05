using System.ComponentModel.DataAnnotations;

namespace AutoLotDAL.EF
{
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int CustId { get; set; }

        public int CarId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
