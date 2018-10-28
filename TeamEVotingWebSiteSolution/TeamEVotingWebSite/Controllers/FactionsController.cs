
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamEVotingWebSite.Models;

namespace TeamEVotingWebSite.Controllers
{
    public class FactionsController : Controller
    {
        List<FactionSet> factionsList = new List<FactionSet>();
        // GET: Factions
        public ActionResult Index()
        {
            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {
                factionsList = teamEVotingDBEntities.FactionSet.ToList();

            }
            return View(factionsList);
        }



        // GET: Factions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Factions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factions/Create
        [HttpPost]
        public ActionResult Create(FactionSet factionSet)
        {

            using (TeamEVotingDBEntities teamEVotingDB = new TeamEVotingDBEntities())
            {
                if (ModelState.IsValid)
                {

                teamEVotingDB.FactionSet.Add(factionSet);
                teamEVotingDB.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }



        // GET: Factions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Factions/Edit/5
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

        // GET: Factions/Delete/5
        public ActionResult Delete(int id)
        {
            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {

                return View(teamEVotingDBEntities.FactionSet.Where(x => x.Faction_Id == id).FirstOrDefault());
            }
        }

        // POST: Factions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
                {
                    FactionSet factionSet = teamEVotingDBEntities.FactionSet.Where(x => x.Faction_Id == id).FirstOrDefault();
                    teamEVotingDBEntities.FactionSet.Remove(factionSet);
                    teamEVotingDBEntities.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
