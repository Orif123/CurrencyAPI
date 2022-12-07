using CurrencyAPI.Models.DataContext;
using CurrencyAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI.Services.Repository
{
    public static class DBRepository
    {
        /// <summary>
        /// Add or update to DB Asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static async Task<int> AddOrUpdateAsync<T>(T entity) where T : class, IEntityWithId
        {
            using (CurrencyTest_DBContext db = new CurrencyTest_DBContext())
            {
                var entityList = db.Set<T>();
                var origin = entityList.SingleOrDefault(p => p.Id.ToString() == entity.Id.ToString());
                if (origin != null)
                {

                    db.Entry(origin).CurrentValues.SetValues(entity);
                }
                else
                {
                    entity.Id = Guid.NewGuid();
                    await entityList.AddAsync(entity);
                }
                return await db.SaveChangesAsync();
            }

        }
        /// <summary>
        /// Get List of <see cref="T"/> entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T>GetAll<T>() where T : class, IEntityWithId
        {
            using (CurrencyTest_DBContext dbContext = new CurrencyTest_DBContext())
            {
                List<T> collection = dbContext.Set<T>().ToList();
                return collection;
            }
        }
    }
}
