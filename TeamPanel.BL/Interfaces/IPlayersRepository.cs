using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamPanel.BL.Context;

namespace TeamPanel.BL.Interfaces
{
    public interface IPlayersRepository
    {
        Task CreatePlayer(BL.Models.Player player);

        Task<BL.Models.Player> GetPlayer(long id);

        Task<IEnumerable<BL.Models.Player>> GetPlayerList(GetPlayersContext context);

        Task EditPlayer(long id, BL.Models.Player newPlayer);

        Task<bool> DeletePlayer(long id);
    }
}
