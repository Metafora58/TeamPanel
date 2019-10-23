using AutoMapper;
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
    public class TeamsRepository : ITeamsRepository
    {
        TeamPanelContext Context;

        public TeamsRepository(TeamPanelContext context)
        {
            Context = context;
        }
        //TODO:
        public async Task<BL.Models.Team> CreateTeam(BL.Models.Team team)
        {
            var newTeam = new Models.Team()
            {
                Name = team.Name,
                CaptainId = team.CaptainId,
                ImageId = team.ImageId,
                //CreationTime = DateTime.Now
            };

            await Context.Team.AddAsync(newTeam);
            newTeam.Identifier = '#' + newTeam.Id.ToString().PadLeft(4,'0');
            await Context.SaveChangesAsync();

            return Mapper.Map<BL.Models.Team>(newTeam);
        }
        //TODO:
        public async Task<BL.Models.Team> GetTeam(int id)
        {
            var team = await Context.Team.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (team == null)
            {
                throw new Exception($"Team wtih id {id} not found");
            }

            return Mapper.Map<BL.Models.Team>(team);
        }

        public async Task<IEnumerable<BL.Models.Team>> GetTeamList(GetTeamsContext context)
        {
            throw new NotImplementedException("not yet implemented");
        }

        public async Task EditTeam(int id, BL.Models.Team newTeam)
        {
            if (newTeam == null)
            {
                throw new Exception("Team not provided");
            }

            var team = await Context.Team.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (team == null)
            {
                throw new Exception($"Team wtih id {id} not found");
            }

            //TODO: handle changes

            await Context.SaveChangesAsync();
        }

        public async Task<bool> DeleteTeam(int id)
        {
            var team = await Context.Team.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (team == null)
            {
                throw new Exception("Error!");
            }

            Context.Remove(team);

            return await Context.SaveChangesAsync() > 0;
        }
    }
}
