using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamPanel.BL.Context;

namespace TeamPanel.BL.Interfaces
{
    public interface IActivitiesRepository
    {
        Task<BL.Models.Activity> CreateActivity(BL.Models.Activity activity);

        Task<BL.Models.Activity> GetActivity(int id);

        Task<IEnumerable<BL.Models.Activity>> GetActivityList(GetActivitiesContext context);

        Task EditActivity(int id, BL.Models.Activity newActivity);

        Task<bool> DeleteActivity(int id);
    }
}
