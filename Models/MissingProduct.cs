using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP2EFCore.Models
{
    [Table("missing_products")]
    public class MissingProduct
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
