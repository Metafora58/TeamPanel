using System;
using System.Collections.Generic;
using System.Text;
using TeamPanel.DAL.Models;
using TeamPanel.BL.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TeamPanel.BL.Context;
using TeamPanel.BL.Interfaces;

namespace TeamPanel.DAL.Repositories
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        TeamPanelContext Context;

        public ActivitiesRepository(TeamPanelContext context)
        {
            Context = context;
        }

        public async Task<BL.Models.Activity> CreateActivity(BL.Models.Activity activity)
        {
            var newActivity = new Models.Activity()
            {
                Name = activity.Name,
                Description = activity.Description,
                ImageId = activity.ImageId,
                CreationTime = DateTime.Now
            };

            await Context.Activity.AddAsync(newActivity);
            await Context.SaveChangesAsync();

            return Mapper.Map<BL.Models.Activity>(newActivity);
        }

        public async Task<BL.Models.Activity> GetActivity(int id)
        {
            var activity = await Context.Activity.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (activity == null)
            {
                throw new Exception($"Activity wtih id {id} not found");
            }

            return Mapper.Map<BL.Models.Activity>(activity);
        }

        public async Task<IEnumerable<BL.Models.Activity>> GetActivityList(GetActivitiesContext context)
        {
            IQueryable<Models.Activity> query = Context.Activity
                .Where(a => context.Id == null || a.Id == context.Id)
                .Where(a => context.Name == null || a.Name.Contains(context.Name))
                .AsQueryable();

            IEnumerable<DAL.Models.Activity> sqlActivities = await query.ToListAsync();

            IEnumerable<BL.Models.Activity> activities = Mapper.Map<IEnumerable<Models.Activity>, IEnumerable<BL.Models.Activity>>(sqlActivities);

            return activities;
        }

        public async Task EditActivity(int id, BL.Models.Activity newActivity)
        {
            if(newActivity == null)
            {
                throw new Exception("Activity not provided");
            }

            var activity = await Context.Activity.Where(a => a.Id == id).FirstOrDefaultAsync();

            if(activity == null)
            {
                throw new Exception($"Activity wtih id {id} not found");
            }

            activity.LastModificationTime = DateTime.Now;

            activity.ImageId = newActivity.ImageId;
            activity.Name = newActivity.Name;
            activity.Description = newActivity.Description;

            await Context.SaveChangesAsync();
        }

        public async Task<bool> DeleteActivity(int id)
        {
            var activity = await Context.Activity.Where(a => a.Id == id).FirstOrDefaultAsync();

            if(activity == null)
            {
                throw new Exception("Error!");
            }

            Context.Remove(activity);

            return await Context.SaveChangesAsync() > 0;
        }
    }
}
