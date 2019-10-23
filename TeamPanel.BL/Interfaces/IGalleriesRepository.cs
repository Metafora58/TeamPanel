using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeamPanel.BL.Interfaces
{
    public interface IGalleriesRepository
    {
        Task CreateImage(BL.Models.Gallery gallery);

        Task<BL.Models.Gallery> GetImage(long id);

        Task<IEnumerable<BL.Models.Gallery>> GetImageList();

        Task EditImage(long id);

        Task<bool> DeleteImage(long id);
    }
}
