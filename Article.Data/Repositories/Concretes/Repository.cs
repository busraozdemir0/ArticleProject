using Article.Core.Entities;
using Article.Data.Context;
using Article.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Article.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext) {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }


        // Ornegin herhangi bir Article icerisindeki gorselin adini cekebilmek icin Image ve Article tablosu include edilmelidir bu metoddaki parametreler de o işe yarar
        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate=null,params Expression<Func<T, object>>[] includeProperties) // params = degisken sayida parametre alabilmesi demektir
        {
            IQueryable<T> query = Table;

            if(predicate != null)
                query = query.Where(predicate);

            if(includeProperties.Any()) // includeProperties icerisinde herhangi bir tane varsa
                foreach(var item in includeProperties)
                    query=query.Include(item);

            return await query.ToListAsync();
        } 

        // Asenkron islem = ayni anda calisma durumunu belirtir
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any()) // includeProperties icerisinde herhangi bir tane varsa
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.SingleAsync();
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity)); // Update'in async karsiligi olmadigi icin asenkron programlama yapisini bozmamak adina bu sekilde yapildi
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if(predicate is not null)
                return await Table.CountAsync(predicate);
            return await Table.CountAsync();
        }
    }
}
