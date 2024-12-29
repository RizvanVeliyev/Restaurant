﻿using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities.Commons;
using Restaurant.DAL.DataContexts;
using Restaurant.DAL.Repositories.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repositories.Implementations.Generic
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entityEntry = await _table.AddAsync(entity);

            return entityEntry.Entity;
        }

        public T Delete(T entity)
        {
            var entityEntry = _table.Remove(entity);

            return entityEntry.Entity;
        }

        public IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> query = _getQueryWithIncludes(include);

            return query;
        }


        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var query = _getQueryWithIncludes(include);

            var entity = await query.FirstOrDefaultAsync(expression);

            return entity;
        }

        public async Task<T?> GetAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var query = _getQueryWithIncludes(include);

            var entity = await query.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public IQueryable<T> GetFilter(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var query = _getQueryWithIncludes(include);

            query = query.Where(expression);

            return query;
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var query = _getQueryWithIncludes(include);

            var result = await query.AnyAsync(expression);

            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            var entityEntry = _table.Update(entity);

            return entityEntry.Entity;
        }


        public IQueryable<T> OrderBy(IQueryable<T> query, Expression<Func<T, object>> expression)
        {
            IQueryable<T> result = query.OrderBy(expression);
            return result;
        }

        public IQueryable<T> OrderByDescending(IQueryable<T> query, Expression<Func<T, object>> expression)
        {
            IQueryable<T> result = query.OrderByDescending(expression);
            return result;
        }

        public IQueryable<T> Paginate(IQueryable<T> query, int limit, int page = 1)
        {
            IQueryable<T> result = query.Skip((page - 1) * limit).Take(limit);
            return result;
        }

        private IQueryable<T> _getQueryWithIncludes(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var query = _table.AsQueryable();

            if (include is { })
                query = include(query);

            return query;
        }
    }
}