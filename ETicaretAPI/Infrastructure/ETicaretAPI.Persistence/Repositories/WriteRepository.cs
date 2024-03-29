using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added; //eklendiyse true dön
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas); //AddRangeAsync Task döndürür ve bilgi alınamıyor demektir.
            return true;
        }

        public bool Remove(T model) //Silinecek olan veri direkt parametre ile geldiğinden böyle yaptık
        {
            EntityEntry entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {//ilgili veriyi önce bulmamız lazım. Sonra remove etmemiz lazım
            T data = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id)); //içerisinde async olduğundan async olarak düzenlendi.
            return Remove(data);
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model); //Table.Update async olmadığından metod async olmayacaktır.
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync(); // "{ return await _context.SaveChangesAsync();}" ile "=> await _context.SaveChangesAsync();" aynıdır


    }
}
