using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamPanel.API
{
    public static class ApiConventions
    {
        #region General

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public static void NoContent()
        {
        }

        #endregion

        #region Activities

        [ProducesResponseType(typeof(BL.Models.Activity), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public static void GetActivity()
        {
        }

        [ProducesResponseType(typeof(IEnumerable<BL.Models.Activity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public static void GetActivities()
        {
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public static void EditActivity()
        {
        }
        #endregion

        #region Images

        [ProducesResponseType(typeof(BL.Models.Gallery), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public static void GetImage()
        {
        }

        #endregion

        #region Team 

        [ProducesResponseType(typeof(BL.Models.Team), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public static void GetTeam()
        {
        }

        [ProducesResponseType(typeof(IEnumerable<BL.Models.Team>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public static void GetTeams()
        {
        }

        #endregion
    }
}
