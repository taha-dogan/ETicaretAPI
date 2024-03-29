using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories //namespace uymadığı için sondaki ".Customer kaldırıldı."
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}


/*
 her bir interface'i tek tek implemente edip kodlama yapmayacağız.
 RDP'nin güzel yanı da artık entity'e özel çalışma yaparken özelleştirilmiş interface ile ve genel olan
 repository aracılığıyla çalışmayı tamamlayabiliyoruz.
    "public class CustomerReadRepository : ICustomerReadRepository"
    şeklinde bir tanımlama yerine
    "public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository"
    şeklinde bir tanımlama ile:

    CUSTOMER'A ÖZEL, READREPOSITORY İÇERİSİNDE NE KADAR METOD VARSA HEPSİ UYGULATILMIŞ OLACAKTIR.
--------------------------------------------------------------------------------------------------------------
    Bu tanımlamada;
    Uygulayıcı =>>>>>> "ReadRepository<Customer>"
    Doğrulayıcı/imza =>>>>>> "ICustomerReadRepository"
--------------------------------------------------------------------------------------------------------------
ReadRepository, ctor'unda parametre istediği için sadece ;

    "namespace ETicaretAPI.Persistence.Repositories //namespace uymadığı için sondaki ".Customer kaldırıldı."
    { 
        public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
        {
        }
    }"
yazarsak hata verir. Bunun için "CustomerReadRepository" ctor'unda yukarıdaki gibi talep etmemiz gerekir.
 
 */