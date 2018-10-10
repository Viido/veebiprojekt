﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamEVotingWebSite.Models;

namespace TeamEVotingWebSite.Controllers
{
    public class RegionsController : Controller
    {
        List<RegionSet> regionsList = new List<RegionSet>();
        // GET: Regions
        public ActionResult Index()
        {
            using(TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {
                regionsList = teamEVotingDBEntities.RegionSet.ToList();
                //regionsList = teamEVotingDBEntities.RegionSet.SqlQuery("select * from RegionSet").ToList();
            }
            return View(regionsList);
        }

        // GET: Regions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        [HttpPost]
        public ActionResult Create(RegionSet region)
        {
            try
            {
                using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
                {
                   
                    if (ModelState.IsValid)
                    {

                    teamEVotingDBEntities.RegionSet.Add(region);
                    teamEVotingDBEntities.SaveChanges();

                    }

                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        //using sql statement
        [HttpPost]
        public ActionResult CreateWithSql(RegionSet region)
        {
            try
            {
                using(TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
                {
                    //teamEVotingDBEntities.Database.ExecuteSqlCommand("INSERT into RegionSet (Region_Name) VALUES (@Region_Name)");
                    //teamEVotingDBEntities.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Regions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Regions/Edit/5
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

        // GET: Regions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Regions/Delete/5
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