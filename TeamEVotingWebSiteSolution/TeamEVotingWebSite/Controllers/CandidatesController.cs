using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamEVotingWebSite.Models;

namespace TeamEVotingWebSite.Controllers
{
    public class CandidatesController : Controller
    {
        List<CandidateSet> candidates = new List<CandidateSet>();
        
        // GET: Candidates
        public ActionResult Index()
        {
            using(TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {

                candidates = teamEVotingDBEntities.CandidateSet.ToList();
            }
            return View(candidates);
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        [HttpPost]
        public ActionResult Create(CandidateSet candidates)
        {
            try
            {
                using (TeamEVotingDBEntities teamEVotingDB = new TeamEVotingDBEntities())
                {
                    teamEVotingDB.CandidateSet.Add(candidates);
                    teamEVotingDB.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Candidates/Edit/5
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

        // GET: Candidates/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidates/Delete/5
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
