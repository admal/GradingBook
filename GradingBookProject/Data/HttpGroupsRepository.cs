using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.Models;

namespace GradingBookProject.Data
{
    public class HttpGroupsRepository
    {
        private HttpRequestService<Groups> requestService = new HttpRequestService<Groups>();


        public async Task<IQueryable<Groups>> getGroups()
        {
            return await requestService.GetAll();
        }
        public async Task AddGroup(Groups group)
        {
            if ((await getGroups()).FirstOrDefault(u => u.id == group.id) != null)
                throw new Exception("There is already such a user!");
            await requestService.PostOne(group);
        }

        public async Task EditGroup(Groups group)
        {
            await requestService.UpdateOne(group.id, group);
        }
        public async Task DeleteGroup(Groups group)
        {
            await requestService.DeleteOne(group.id);
        }

    }
}
