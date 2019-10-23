using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamPanel.BL.Interfaces;
using TeamPanel.DAL.Models;

namespace TeamPanel.DAL.Repositories
{
    public class GalleriesRepository : IGalleriesRepository
    {
        TeamPanelContext Context;

        public GalleriesRepository(TeamPanelContext context)
        {
            Context = context;
        }

        public async Task CreateImage(BL.Models.Gallery gallery)
        {
            throw new NotImplementedException("not yet implemented");
        }

        public async Task<BL.Models.Gallery> GetImage(long id)
        {
            throw new NotImplementedException("not yet implemented");
        }

        public async Task<IEnumerable<BL.Models.Gallery>> GetImageList()
        {
            throw new NotImplementedException("not yet implemented");
        }

        public async Task EditImage(long id)
        {
            throw new NotImplementedException("not yet implemented");
        }

        public async Task<bool> DeleteImage(long id)
        {
            throw new NotImplementedException("not yet implemented");
        }
    }
}
