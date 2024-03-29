
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new Product {Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name = "Dolap", Stock = 10, Price = 100.99F},
                new Product {Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name = "Araba", Stock = 20, Price = 100000.50F},
                new Product {Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name = "Ayakkabı", Stock = 30, Price = 70.89F},
                new Product {Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name = "Telefon", Stock = 40, Price = 19900.99F},
                new Product {Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name = "Cüzdan", Stock = 50, Price = 100.99F},
            });

            await _productWriteRepository.SaveAsync();
        } //hata alırsan buraya breakpoint at, eğer dispose ile alakalı bir hata var ise "services.AddScoped" kaynaklıdır.  

    }
}
