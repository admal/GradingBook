using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.ViewModels;


namespace GradingBookProject.Data
{
    public class HttpGroupDetailsRepository : HttpRepository<GroupDetailsViewModel, HttpGroupDetailsRequestService>
    {
        public async Task<bool> DetailExists(GroupDetailsViewModel detail )
        {
            return await DetailExists(detail.group_id, detail.user_id);
        }

        public async Task<bool> DetailExists(int groupId, int userId )
        {
            return await requestService.DetailExists(groupId, userId);
        }

        public async Task<GroupDetailsViewModel> RemoveDetail(int groupId, int userId)
        {
            return await requestService.RemoveDetail(groupId, userId);
        }
        public async Task<GroupDetailsViewModel> RemoveDetail(GroupDetailsViewModel detail)
        {
            return await requestService.RemoveDetail(detail.group_id,detail.group_id);
        }
        public async Task<ICollection<GroupDetailsViewModel>> GetGroupDetailsForUser(int userId)
        {
            return await requestService.GetGroupDetailsForUser(userId);
        }
        public async Task<ICollection<GroupDetailsViewModel>> GetGroupDetailsForGroup(int groupId)
        {
            return await requestService.GetGroupDetailsForGroup(groupId);
        }
    }
}
