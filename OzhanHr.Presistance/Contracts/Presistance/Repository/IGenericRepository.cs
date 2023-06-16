﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.Contracts.Presistance.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> IsExist(int id);
    }
}
