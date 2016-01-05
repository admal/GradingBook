using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Data
{
    /// <summary>
    /// Base class for basic data operations on entities via http requests.
    /// </summary>
    /// <typeparam name="T">Model type.</typeparam>
    /// <typeparam name="Y">Type of request service.</typeparam>
    public class HttpRepository<T, Y>
        where Y : HttpRequestService<T>, new()
        where T : EntityViewModel
    {
        protected Y requestService;

        public HttpRepository()
        {
            requestService = new Y();
        }
        /// <summary>
        /// Get all entities of type T
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<T>> GetAll()
        {
            return await requestService.GetAll();
        }
        /// <summary>
        /// Gets an entity of a given id.
        /// </summary>
        /// <param name="id">Id of an entity wanted</param>
        /// <returns>Subject</returns>
        public async Task<T> GetOne(int id )
        {
            return await requestService.GetOne(id);
        }
        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">Grade to be added.</param>
        /// <returns></returns>
        public async Task<T> AddOne(T entity)
        {
            if ((await GetOne(entity.id)) != null)
                throw new Exception("There is already such an object!");
            return await requestService.PostOne(entity);
        }
        /// <summary>
        /// Edits given entity.
        /// </summary>
        /// <param name="entity">Edited entity</param>
        /// <returns></returns>
        public async Task EditOne(T entity)
        {
            await requestService.UpdateOne(entity.id, entity);
        }
        /// <summary>
        /// Deletes a given entity.
        /// </summary>
        /// <param name="entity">Entity to be deleted.</param>
        /// <returns></returns>
        public async Task DeleteOne(T entity)
        {
            if (await requestService.GetOne(entity.id) == null)
                throw new Exception("Such entity does not exist!");
            await requestService.DeleteOne(entity.id);
        }
    }
}
