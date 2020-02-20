using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamPanel.BL.Context;
using TeamPanel.BL.Interfaces;
using TeamPanel.DAL.Models;

namespace TeamPanel.DAL.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        readonly TeamPanelContext Context;

        public PlayersRepository(TeamPanelContext context)
        {
            Context = context;
        }

        public async Task CreatePlayer(BL.Models.Player player)
        {
            throw new NotImplementedException("not yet implemented");
        }

        public async Task<BL.Models.Player> GetPlayer(long id)
        {
            throw new NotImplementedException("not yet implemented");
        }

        public async Task<IEnumerable<BL.Models.Player>> GetPlayerList(GetPlayersContext context)
        {
            throw new NotImplementedException("not yet implemented");
        }

        public async Task EditPlayer(long id, BL.Models.Player newPlayer)
        {
            throw new NotImplementedException("not yet implemented");
        }

        public async Task<bool> DeletePlayer(long id)
        {
            throw new NotImplementedException("not yet implemented");
        }
    }
}
