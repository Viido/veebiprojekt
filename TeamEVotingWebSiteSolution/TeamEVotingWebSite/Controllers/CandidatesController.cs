﻿using System;
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
                //Faction member + 1, sest üks member on juures nüüd
                var selectedFaction = candidates.Faction_Id;
                var addMember = teamEVotingDB.FactionSet.Single(addMembers => addMembers.Faction_Id == selectedFaction);
                addMember.NumberOfMembers++;
                teamEVotingDB.CandidateSet.Add(candidates);
                candidates.NumberOfVotes = 0;
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
        public ActionResult GroupCandidates()
        {
            CandidateSet candidate = new CandidateSet();
            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {
                //kasutab Count, Sum, Min, Max, Average käske, LINQ = SQL
                var candidatesCount = teamEVotingDBEntities.CandidateSet.Count();
                var factionsCount = teamEVotingDBEntities.FactionSet.Count();
                var regionsCount = teamEVotingDBEntities.RegionSet.Count();

                var sumCandidates = teamEVotingDBEntities.CandidateSet.Sum(x => x.Candidate_Age);
                var youngestCandidate = teamEVotingDBEntities.CandidateSet.Min(x => x.Candidate_Age);
                var oldestCandidate = teamEVotingDBEntities.CandidateSet.Max(x => x.Candidate_Age);

                var averageCandidateAge = teamEVotingDBEntities.CandidateSet.Average(x => x.Candidate_Age);

                ViewBag.candidatesCount = candidatesCount;

                ViewBag.factionsCount = factionsCount;
                ViewBag.regionsCount = regionsCount;
                ViewBag.sumCandidates = sumCandidates;
                ViewBag.youngestCandidate = youngestCandidate;
                ViewBag.oldestCandidate = oldestCandidate;
                ViewBag.averageCandidateAge = averageCandidateAge;


                var popularBrowser = teamEVotingDBEntities.VisitorInfo.GroupBy(x => x.VisitorBrowser).OrderByDescending(gp => gp.Count()).Take(1).Select(g => g.Key).ToList();

                foreach (var item in popularBrowser)
                {
                    ViewBag.popularBrowser = item;
                }
                var popularVisitingTime = teamEVotingDBEntities.VisitorInfo.GroupBy(t => t.Visited_DateTime).OrderByDescending(gp => gp.Count()).Take(1).Select(g => g.Key).ToList();

                foreach (var item in popularVisitingTime)
                {
                    var dateTime = item.Value;
                    var hour = dateTime.Hour;
                    var minute = dateTime.Minute;
                    if (minute < 10)
                    {

                        ViewBag.popularTime = hour + ":0" + minute;
                    }
                    else
                    {
                        ViewBag.popularTime = hour + ":" + minute;
                    }
                }

            }


            return View();
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
