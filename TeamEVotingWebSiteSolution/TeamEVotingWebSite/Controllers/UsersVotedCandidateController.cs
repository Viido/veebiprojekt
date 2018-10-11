using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamEVotingWebSite.Controllers
{
    public class UsersVotedCandidateController : Controller
    {
        // GET: UsersVotedCandidate
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsersVotedCandidate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersVotedCandidate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersVotedCandidate/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersVotedCandidate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersVotedCandidate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersVotedCandidate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersVotedCandidate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
