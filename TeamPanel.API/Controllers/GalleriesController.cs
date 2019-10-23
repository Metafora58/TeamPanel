using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamPanel.BL.Interfaces;

namespace TeamPanel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : ControllerBase
    {
        IGalleriesRepository _galleriesRepository;

        public GalleriesController(IGalleriesRepository galleriesRepository)
        {
            _galleriesRepository = galleriesRepository;
        }

        [HttpGet]
        [Route("id")]
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.GetImage))]
        public async Task<BL.Models.Gallery> GetImage(long id)
        {
            var image = await _galleriesRepository.GetImage(id);

            return image;
        }

    }
}