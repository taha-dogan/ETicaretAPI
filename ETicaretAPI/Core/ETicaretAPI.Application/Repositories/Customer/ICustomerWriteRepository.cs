using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories //namespace uymadığı için sondaki ".Customer kaldırıldı."
{
    public interface ICustomerWriteRepository : IWriteRepository<Customer>
    {
    }
}
