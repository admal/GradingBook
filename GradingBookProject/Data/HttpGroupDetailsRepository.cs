using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.Models;

namespace GradingBookProject.Data
{
    public class HttpGroupDetailsRepository : HttpRepository<GroupDetails, HttpGroupDetailsRequestService>
    {
        public async Task<bool> DetailExists(GroupDetails detail )
        {
            return await DetailExists(detail.group_id, detail.user_id);
        }

        public async Task<bool> DetailExists(int groupId, int userId )
        {
            return await requestService.DetailExists(groupId, userId);
        }

        public async Task<GroupDetails> RemoveDetail(int groupId, int userId)
        {
            return await requestService.RemoveDetail(groupId, userId);
        }
        public async Task<GroupDetails> RemoveDetail(GroupDetails detail)
        {
            return await requestService.RemoveDetail(detail.group_id,detail.group_id);
        }
    }
}
