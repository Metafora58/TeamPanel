using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamPanel.BL.Context;

namespace TeamPanel.BL.Interfaces
{
    public interface ITeamsRepository
    {
        Task CreateTeam(BL.Models.Team team);

        Task<BL.Models.Team> GetTeam(int id);

        Task<IEnumerable<BL.Models.Team>> GetTeamList(GetTeamsContext context);

        Task EditTeam(int id, BL.Models.Team newTeam);

        Task<bool> DeleteTeam(int id);
    }
}
