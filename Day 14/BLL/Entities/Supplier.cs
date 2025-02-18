using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        public required string CompanyName { get; set; }
    }
}
