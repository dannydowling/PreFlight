﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PreFlight.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Get(Guid id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void SaveChanges();
    }
}
