using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.EF
{
    public class MyDataInitializer : DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            base.Seed(context);
        }
    }
}
