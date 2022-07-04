using BusinessLayer.Generic;
using BusinessLayer.Interfaces;
using DataAccessLayer.Generic;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(IGenericRepository<Product> genericRepository) : base(genericRepository)
        {
        }
    }
}
