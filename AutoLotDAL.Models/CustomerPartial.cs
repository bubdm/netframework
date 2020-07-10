namespace AutoLotDAL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Customer
    {
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
