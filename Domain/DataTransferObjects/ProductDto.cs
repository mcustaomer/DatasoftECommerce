using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }
    }
}
