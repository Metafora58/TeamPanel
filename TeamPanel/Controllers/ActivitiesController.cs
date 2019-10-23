using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamPanel.Api.Client.Contracts;

namespace TeamPanel.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IActivitiesClient _activitiesClient;

        public ActivitiesController(IActivitiesClient activities)
        {
            _activitiesClient = activities;
        }
        // GET: Activities
        public ActionResult ActivityList()
        {
            var nesto = _activitiesClient.GetActivitiesAsync();
            
            return View();
        }

        // GET: Activities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Activities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Activities/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}