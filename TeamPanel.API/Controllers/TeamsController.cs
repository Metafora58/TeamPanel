using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamPanel.BL.Context;
using TeamPanel.BL.Interfaces;

namespace TeamPanel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        readonly ITeamsRepository _teamsRepository;

        public TeamsController(ITeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }


        [HttpGet]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.GetTeams))]
        public async Task<IEnumerable<BL.Models.Team>> GetTeams(GetTeamsContext context)
        {
            var teams = await _teamsRepository.GetTeamList(context);

            return teams;
        }

        [HttpGet]
        [Route("id")]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.GetTeam))]
        public async Task<BL.Models.Team> GetTeam(int id)
        {
            var team = await _teamsRepository.GetTeam(id);

            return team;
        }

        [HttpPost]
        [Route("id")]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.GetActivity))]
        public async Task<ActionResult> CreateTeam(BL.Models.Team team)
        {
            var request = await _teamsRepository.CreateTeam(team);

            if (request != null)
            {
                return Created($"{this.Request.Path}/{request.Id}", request);
            }
            else
            {
                throw new Exception("Internal server error");
            }
        }

        [HttpPatch]
        [Route("id")]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.EditActivity))]
        public async Task<ActionResult> EditTeam([FromRoute]int id, [FromBody]BL.Models.Team team)
        {
            await _teamsRepository.EditTeam(id, team);

            return NoContent();
        }

        [HttpDelete]
        [Route("id")]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.NoContent))]
        public async Task<ActionResult> DeleteTeam([FromRoute]int id)
        {
            await _teamsRepository.DeleteTeam(id);

            return NoContent();
        }
    }
}