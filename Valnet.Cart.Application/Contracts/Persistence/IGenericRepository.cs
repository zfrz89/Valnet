﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valnet.Cart.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id); 
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
