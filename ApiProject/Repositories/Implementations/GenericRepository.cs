﻿using ApiProject.Db;
using ApiProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiProject.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        private readonly ProjectContext _context;
        public GenericRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = default)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if(filter is not null)
                query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter = default)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if (filter is not null)
                query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
