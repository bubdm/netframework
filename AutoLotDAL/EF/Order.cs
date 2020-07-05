namespace AutoLotDAL.EF
{
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        public int CustId { get; set; }

        public int CarId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
