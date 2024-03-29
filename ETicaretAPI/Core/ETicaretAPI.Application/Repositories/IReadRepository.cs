using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(); //hepsini al
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method); //verilen şart ifadesinde doğru olan datalar sorgulanıp getirilir. Şarta uygun birden fazla veri gelir.
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method); //şarta uygun tek veri. FirstOrDefault'un asenkron fonksiyonunu kullanacaktır.
        Task<T> GetByIdAsync(string id);
    }
}
