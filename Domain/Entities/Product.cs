﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }
    }
}
