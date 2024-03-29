﻿using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);


        Task<bool> Remove(T model);
        Task<bool> Remove(string id);

        Task<bool> UpdateAsync(T model);

        Task<int> SaveAsync();


        



    }
}
