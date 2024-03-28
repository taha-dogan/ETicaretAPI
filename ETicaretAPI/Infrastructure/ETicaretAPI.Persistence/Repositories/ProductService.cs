using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new()
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "P1",
                    CreatedDate = DateTime.Now,
                    Price = 100.00F,
                    Stock = 10
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "P2",
                    CreatedDate = DateTime.Now,
                    Price = 200.99F,
                    Stock = 2
                },
            };
        }
    }
}
