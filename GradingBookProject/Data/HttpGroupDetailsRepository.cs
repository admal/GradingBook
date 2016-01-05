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
    /// Class to handle database operations on GroupDetails. Operations are done via http requests.
    /// </summary>
    public class HttpGroupDetailsRepository : HttpRepository<GroupDetailsViewModel, HttpGroupDetailsRequestService>
    {
        /// <summary>
        /// Chhecks if given detail exists.
        /// </summary>
        /// <param name="detail">Detail view model to check</param>
        /// <returns>true - if exists, false - otherwise</returns>
        public async Task<bool> DetailExists(GroupDetailsViewModel detail )
        {
            return await DetailExists(detail.group_id, detail.user_id);
        }
        /// <summary>
        /// Chhecks if given detail with given ids exists.
        /// </summary>
        /// <param name="groupId">group id</param>
        /// <param name="userId">user id</param>
        /// <returns>true - if exists, false - otherwise</returns>
        public async Task<bool> DetailExists(int groupId, int userId )
        {
            return await requestService.DetailExists(groupId, userId);
        }
        /// <summary>
        /// Deletes detail with given ids.
        /// </summary>
        /// <param name="groupId">group id</param>
        /// <param name="userId">user id</param>
        /// <returns>deleted detail</returns>
        public async Task<GroupDetailsViewModel> RemoveDetail(int groupId, int userId)
        {
            return await requestService.RemoveDetail(groupId, userId);
        }
        /// <summary>
        /// Deletes detail.
        /// </summary>
        /// <param name="detail">detail to delete</param>
        /// <returns>deleted detail</returns>
        public async Task<GroupDetailsViewModel> RemoveDetail(GroupDetailsViewModel detail)
        {
            return await requestService.RemoveDetail(detail.group_id,detail.group_id);
        }
        /// <summary>
        /// Get all details for given user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>List of fetails</returns>
        public async Task<ICollection<GroupDetailsViewModel>> GetGroupDetailsForUser(int userId)
        {
            return await requestService.GetGroupDetailsForUser(userId);
        }
        /// <summary>
        /// Get all details for given group
        /// </summary>
        /// <param name="groupId">group id</param>
        /// <returns>List of fetails</returns>
        public async Task<ICollection<GroupDetailsViewModel>> GetGroupDetailsForGroup(int groupId)
        {
            return await requestService.GetGroupDetailsForGroup(groupId);
        }
    }
}
