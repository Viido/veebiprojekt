using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamEVotingWebSite.Models;


namespace TeamEVotingWebSite.Controllers
{
    public class UsersController : Controller
    {
        List<UserSet> usersList = new List<UserSet>();
        // GET: Users
        public ActionResult Index()
        {
            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {
                usersList = teamEVotingDBEntities.UserSet.ToList();


            }
            return View(usersList);
        }

        public ActionResult SeeVotedCandidates()
        {
            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities()){

                var result = (from u in teamEVotingDBEntities.UserSet
                              join c in teamEVotingDBEntities.CandidateSet on u.Candidate_Id equals c.Candidate_Id
                              select new UserVotedCandidatesVM
                              {
                                  User_Id = u.User_Id,
                                  User_FirstName = u.User_FirstName,
                                  User_LastName = u.User_LastName,
                                  Candidate_Id = c.Candidate_Id,
                                  Candidate_FirstName = c.Candidate_FirstName,
                                  Candidate_LastName = c.Candidate_LastName,
                                  Candidate_Age = c.Candidate_Age

                              }).ToList();

                return View(result);
            }


        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(UserSet user)
        {
            try
            {
                // TODO: Add insert logic here
                using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
                {
                    if (ModelState.IsValid)
                    {

                        teamEVotingDBEntities.UserSet.Add(user);
                        teamEVotingDBEntities.SaveChanges();
                    }
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
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

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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
