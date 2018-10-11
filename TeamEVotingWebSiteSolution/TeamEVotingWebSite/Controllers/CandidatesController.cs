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
           
            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {

                var result = (from c in teamEVotingDBEntities.CandidateSet
                              join r in teamEVotingDBEntities.RegionSet on c.Region_Id equals r.Region_Id
                              join f in teamEVotingDBEntities.FactionSet on c.Faction_Id equals f.Faction_Id
                              select new CreateCandidateVM
                              {
                               Faction_Id = f.Faction_Id,
                               Region_Id = r.Region_Id,
                               Candidate_Id = c.Candidate_Id,
                               Candidate_Age = c.Candidate_Age,
                               Candidate_FirstName = c.Candidate_FirstName,
                               Candidate_LastName = c.Candidate_LastName,
                               Faction_Name = f.Faction_Name,
                               NumberOfVotes = c.NumberOfVotes,
                               Region_Name = r.Region_Name
                               

                              }).ToList();

                return View(result);
            }
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            CandidateSet candidates = new CandidateSet();
            using (TeamEVotingDBEntities teamEVotingDB = new TeamEVotingDBEntities())
            {

                candidates.regions = teamEVotingDB.RegionSet.ToList();
                candidates.factions = teamEVotingDB.FactionSet.ToList();
            }
            return View(candidates);
        }

        // POST: Candidates/Create
        [HttpPost]
        public ActionResult Create(CandidateSet candidates)
        {
            
                
           
                using (TeamEVotingDBEntities teamEVotingDB = new TeamEVotingDBEntities())
                {
                    teamEVotingDB.CandidateSet.Add(candidates);
                    teamEVotingDB.SaveChanges();
                }

                return RedirectToAction("Index");
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
            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {

            return View(teamEVotingDBEntities.CandidateSet.Where(x => x.Candidate_Id == id).FirstOrDefault());
            }
        }

        // POST: Candidates/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
                {
                    CandidateSet candidateSet = teamEVotingDBEntities.CandidateSet.Where(x => x.Candidate_Id == id).FirstOrDefault();
                    teamEVotingDBEntities.CandidateSet.Remove(candidateSet);
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
