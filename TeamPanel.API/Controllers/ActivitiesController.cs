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
    public class ActivitiesController : ControllerBase
    {
        IActivitiesRepository _activitiesRepository;

        public ActivitiesController(IActivitiesRepository activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;
        }

        [HttpGet]
        [Route("id")]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.GetActivity))]
        public async Task<BL.Models.Activity> GetActivity(int id)
        {
            var activity = await _activitiesRepository.GetActivity(id);

            return activity;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.GetActivity))]
        public async Task<IEnumerable<BL.Models.Activity>> GetActivities([FromQuery]GetActivitiesContext activitiesContext)
        {
            var activities = await _activitiesRepository.GetActivityList(activitiesContext);

            return activities;
        }

        [HttpPost]
        [Route("id")]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.GetActivity))]
        public async Task<ActionResult> CreateActivity(BL.Models.Activity activity)
        {
            var request = await _activitiesRepository.CreateActivity(activity);

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
        public async Task<ActionResult> EditActivity([FromRoute]int id, [FromBody]BL.Models.Activity activity)
        {
            await _activitiesRepository.EditActivity(id, activity);

            return NoContent();
        }

        [HttpDelete]
        [Route("id")]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.NoContent))]
        public async Task<ActionResult> DeleteActivity([FromRoute]int id)
        {
            await _activitiesRepository.DeleteActivity(id);

            return NoContent();
        }
    }
}
