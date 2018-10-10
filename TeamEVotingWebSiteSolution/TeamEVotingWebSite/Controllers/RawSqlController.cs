using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamEVotingWebSite.Models;

namespace TeamEVotingWebSite.Controllers
{
    public class RawSqlController : Controller
    {
        List<RegionSet> regionsList = new List<RegionSet>();
        // GET: RawSql
        public ActionResult Index()
        {
            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {
                //regionsList = teamEVotingDBEntities.RegionSet.ToList();
                regionsList = teamEVotingDBEntities.RegionSet.SqlQuery("select * from RegionSet").ToList();
            }
            return View(regionsList);
        }
        public ActionResult IndexJoin()
        {
            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {
                //regionsList = teamEVotingDBEntities.RegionSet.ToList();
                //var innerJoinQuery = from region in teamEVotingDBEntities.RegionSet
                //                     join rq in teamEVotingDBEntities.CandidateSet on region.Region_Id equals rq.Region_Id
                //                     select new CandidateSet
                //                     {
                //                         //Region_Id = region.Region_Id,

                //                     }
                //**?????
                var result = from user in teamEVotingDBEntities.UserSet
                             join uc in teamEVotingDBEntities.CandidateSet on user.Candidate_Id equals uc.Candidate_Id
                             select new
                             {
                                 user.User_FirstName,
                                 user.User_LastName,
                                 uc.Candidate_FirstName,
                                 uc.Candidate_LastName
                             };
                                     

            return View(result);
            }
        }

        // GET: RawSql/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RawSql/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RawSql/Create
        [HttpPost]
        public ActionResult Create(RegionSet region)
        {
            try
            {
                using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
                {
                    List<object> list = new List<object>();
                    list.Add(region.Region_Name);
                    object[] allitems = list.ToArray();
                    int output = teamEVotingDBEntities.Database.ExecuteSqlCommand("INSERT into RegionSet(Region_Name) values (@p0)", allitems);

                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: RawSql/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RawSql/Edit/5
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

        // GET: RawSql/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RawSql/Delete/5
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
