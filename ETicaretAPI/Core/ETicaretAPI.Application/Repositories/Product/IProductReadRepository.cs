﻿using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories //namespace uymadığı için sondaki ".Product kaldırıldı."
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}
