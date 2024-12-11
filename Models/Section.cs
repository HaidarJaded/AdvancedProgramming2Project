using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP2EFCore.Models
{
    public class Section
    {
        public int Id { get; set; }
        public required string Name{ get; set; }
        public List<Product> Products { get; set; }
    }
}
