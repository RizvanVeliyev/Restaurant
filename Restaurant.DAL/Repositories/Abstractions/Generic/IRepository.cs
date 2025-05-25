﻿using Microsoft.EntityFrameworkCore.Query;
using Restaurant.Core.Entities.Commons;
using System.Linq.Expressions;

namespace Restaurant.DAL.Repositories.Abstractions.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Func<IQueryable<T>,IIncludableQueryable<T,object>>? include=null);
        IQueryable<T> GetFilter(Expression<Func<T,bool>> expression,Func<IQueryable<T>,IIncludableQueryable<T,object>>? include=null);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<T?> GetAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<int> SaveChangesAsync();
        IQueryable<T> OrderBy(IQueryable<T> query, Expression<Func<T, object>> expression);
        IQueryable<T> OrderByDescending(IQueryable<T> query, Expression<Func<T, object>> expression);
        IQueryable<T> Paginate(IQueryable<T> query, int limit, int page = 1);


    }
}
