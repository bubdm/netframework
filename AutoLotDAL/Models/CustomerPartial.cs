using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.EF
{
    public partial class Customer
    {
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
