using Carebook.DAL.Context;
using Carebook.DAL.Repositories.Abstracts;
using Carebook.ENTITIES.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
       private readonly AppDbContex _DbContex;

        public BaseRepository(AppDbContex DbContex)
        {
            this._DbContex = DbContex;    
        }


        public void Add(T item)
        {
            _DbContex.Set<T>().Add(item);
            _DbContex.SaveChanges();
        }

        public async Task AddAsync(T item)
        {
           await _DbContex.Set<T>().AddAsync(item);
           await _DbContex.SaveChangesAsync();
        }

        public void AddRange(List<T> list)
        {
            _DbContex.Set<T>().AddRange(list);
            _DbContex.SaveChanges();
        }

        public async Task AddRangeAsync(List<T> list)
        {
           await _DbContex.Set<T>().AddRangeAsync(list);
           await _DbContex.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _DbContex.Set<T>().AnyAsync(exp);
        }

        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            _DbContex.SaveChanges();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (var item in list) Delete(item);
        }

        public void Destroy(T item)
        {
            _DbContex.Set<T>().Remove(item);
            _DbContex.SaveChanges();
        }

        public void DestroyRange(List<T> list)
        {
            _DbContex.Set<T>().RemoveRange(list);
            _DbContex.SaveChanges();    
        }

        public async Task<T> FindAsync(int id)
        {
           return _DbContex.Set<T>().Find(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
          return await _DbContex.Set<T>().FirstOrDefaultAsync(exp);
        }

        public IQueryable<T> GetActives()
        {
          return Where( x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        public IQueryable<T> GetAll()
        {
          return  _DbContex.Set<T>().AsQueryable();   
        }

        public IQueryable<T> GetModifieds()
        {
         return   Where(x => x.Status == ENTITIES.Enums.DataStatus.Update);
        }

        public IQueryable<T> GetPassives()
        {
          return  Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
           return _DbContex.Set<T>().Select(exp);
        }

        public async Task Update(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Update;
            item.ModifiedDate = DateTime.Now;
            T orginal = await FindAsync(item.ID);
            _DbContex.Entry(orginal).CurrentValues.SetValues(item);
            await _DbContex.SaveChangesAsync();  
        }

        public async Task UpdateRange(List<T> list)
        {
            foreach (var item in list) await Update(item);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _DbContex.Set<T>().Where(exp);
        }

        void IRepository<T>.Add(T item)
        {
            _DbContex.Set<T>().Add(item);
            _DbContex.SaveChanges();
        }
    }
    
    }

