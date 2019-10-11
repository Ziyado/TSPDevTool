using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using TSPDevTool.BLL;
using TSPDevTools.Model;
using TSPDevTool.DAL;
using TSPDevTool.UI.Models;

namespace TSPDevTool.UI.Controllers
{
    [Authorize(Users = "test")]
    public class SearchController : Controller
    {
        private TSPEntities db;
        // Creating Objects from the BLL 
        EmployeeBusinessManager employeeBusinessManager;
        RoleBusinessManager roleBusinessManager;
        WorkloadBusinessManager workloadbusinessManager;
        SkillsBusinessManager skillsbusinessManager;
        EmpSkillBusinessManager empskilssbusinessManager;
        SkillLevelsBusinessManager skilllevelbusinessManager;
        SubsidariesBusinessManager subsidiariesbusinessManager;
        EmpSubsBusinessManager empSubsBusinessManager;
        TracksBusinessManager tracksbusinessManager;
        // new variabless
        static List<Skill> searchSkills = new List<Skill>(); // new list for skills 
        static List<Track> searchTracks = new List<Track>(); // new list for tracks 
        static List<Subsidary> searchSubs = new List<Subsidary>(); // new list for subs

        public SearchController()
        {
            db = new TSPEntities();
            employeeBusinessManager = new EmployeeBusinessManager(db);
            roleBusinessManager = new RoleBusinessManager(db);
            workloadbusinessManager = new WorkloadBusinessManager(db);
            skillsbusinessManager = new SkillsBusinessManager(db);
            empskilssbusinessManager = new EmpSkillBusinessManager(db);
            skilllevelbusinessManager = new SkillLevelsBusinessManager(db);
            subsidiariesbusinessManager = new SubsidariesBusinessManager(db);
            empSubsBusinessManager = new EmpSubsBusinessManager(db);
            tracksbusinessManager = new TracksBusinessManager(db);

        } // Objects from BLL 

        // GET: Search
        [Authorize(Users = "test")]
        public ActionResult Index()
        {

            return View(searchSkills.ToList());
        }
        [Authorize(Users = "test")]
        public ActionResult SearchByTrack()
        {
            ViewBag.SkillLevels = new SelectList(db.SkillLevels, "ID", "Name");// select statement in ef
            return View(searchTracks.ToList());
        }
        [Authorize(Users = "test")]
        public ActionResult SearchBySubs()
        {
            return View(searchSubs.ToList());
        }
        // GET: Search/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpSkill empSkill = db.EmpSkills.Find(id);
            if (empSkill == null)
            {
                return HttpNotFound();
            }
            return View(empSkill);
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            ViewBag.EmpID = new SelectList(db.Employees, "ID", "Name");
            ViewBag.SkillD = new SelectList(db.Skills, "ID", "Name");
            ViewBag.SkillLevelID = new SelectList(db.SkillLevels, "ID", "Name");
            return View();
        }

        // POST: Search/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmpID,SkillD,SkillLevelID")] EmpSkill empSkill)
        {
            if (ModelState.IsValid)
            {
                db.EmpSkills.Add(empSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpID = new SelectList(db.Employees, "ID", "Name", empSkill.EmpID);
            ViewBag.SkillD = new SelectList(db.Skills, "ID", "Name", empSkill.SkillD);
            ViewBag.SkillLevelID = new SelectList(db.SkillLevels, "ID", "Name", empSkill.SkillLevelID);
            return View(empSkill);
        }

        // GET: Search/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpSkill empSkill = db.EmpSkills.Find(id);
            if (empSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpID = new SelectList(db.Employees, "ID", "Name", empSkill.EmpID);
            ViewBag.SkillD = new SelectList(db.Skills, "ID", "Name", empSkill.SkillD);
            ViewBag.SkillLevelID = new SelectList(db.SkillLevels, "ID", "Name", empSkill.SkillLevelID);
            return View(empSkill);
        }

        // POST: Search/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmpID,SkillD,SkillLevelID")] EmpSkill empSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.Employees, "ID", "Name", empSkill.EmpID);
            ViewBag.SkillD = new SelectList(db.Skills, "ID", "Name", empSkill.SkillD);
            ViewBag.SkillLevelID = new SelectList(db.SkillLevels, "ID", "Name", empSkill.SkillLevelID);
            return View(empSkill);
        }

        // GET: Search/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpSkill empSkill = db.EmpSkills.Find(id);
            if (empSkill == null)
            {
                return HttpNotFound();
            }
            return View(empSkill);
        }

        // POST: Search/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            EmpSkill empSkill = db.EmpSkills.Find(id);
            db.EmpSkills.Remove(empSkill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //************************************ Autocomplete *********************************************
        // autocomplete for skills 
        public JsonResult GetAutoSkills(string Prefix)
        {
            List<Skill> result;
            List<Skill> all;
            if (string.IsNullOrEmpty(Prefix))
            {

                all = skillsbusinessManager.GetAll();
                result = all.Except(searchSkills, new IdComparer()).ToList();
            }
            else
            {
                all = skillsbusinessManager.GetAll();
                result = all.Except(searchSkills, new IdComparer()).ToList();
                result = result.Where(s => s.Name.ToLower().Contains(Prefix.ToLower())).ToList();
            }

            var translatedResult = SkillModel.Translate(result);
            return Json(translatedResult, JsonRequestBehavior.AllowGet);
        }
        // autocomplete for tracks 
        public JsonResult GetAutoTracks(string Prefix)
        {
            List<Track> result;
            List<Track> all;
            if (string.IsNullOrEmpty(Prefix))
            {

                all = tracksbusinessManager.GetAll();
                result = all.Except(searchTracks, new IdComparerTrack()).ToList();
            }
            else
            {
                all = tracksbusinessManager.GetAll();
                result = all.Except(searchTracks, new IdComparerTrack()).ToList();
                result = result.Where(s => s.Name.ToLower().Contains(Prefix.ToLower())).ToList();
            }

            var translatedResult = TrackModel.Translate(result);
            return Json(translatedResult, JsonRequestBehavior.AllowGet);
        }
        // autocomplete for subs 
        public JsonResult GetAutoSubs(string Prefix)
        {
            List<Subsidary> result;
            List<Subsidary> all;
            if (string.IsNullOrEmpty(Prefix))
            {

                all = subsidiariesbusinessManager.GetAll();
                result = all.Except(searchSubs, new IdComparerSubs()).ToList();
            }
            else
            {
                all = subsidiariesbusinessManager.GetAll();
                result = all.Except(searchSubs, new IdComparerSubs()).ToList();
                result = result.Where(s => s.Name.ToLower().Contains(Prefix.ToLower())).ToList();
            }

            var translatedResult = SubsModel.Translate(result);
            return Json(translatedResult, JsonRequestBehavior.AllowGet);
        }

        // *****************************************ADD***************************************
        // add skills
        public ActionResult AddSkills(int skillId, string skillname)
        {
            var skill = new Skill();
            skill.Name = skillname;
            skill.ID = skillId;
            if (searchSkills.Where(n => n.ID == skillId).FirstOrDefault() == null)
            {
                searchSkills.Add(skill); // adding
            }

            return PartialView("_SkillsFilter", searchSkills);
        }
        // add tracks 
        public ActionResult AddTracks(int trackId, string trackname)
        {
            var track = new Track();
            track.Name = trackname;
            track.ID = trackId;
            if (searchTracks.Where(n => n.ID == trackId).FirstOrDefault() == null)
            {
                searchTracks.Add(track); // adding
            }

            return PartialView("_TracksFilter", searchTracks);
        }
        // add subs
        public ActionResult AddSubs(int subId, string subname)
        {
            var sub = new Subsidary();
            sub.Name = subname;
            sub.ID = subId;
            if (searchSubs.Where(n => n.ID == subId).FirstOrDefault() == null)
            {
                searchSubs.Add(sub); // adding
            }

            return PartialView("_SubsFilter", searchSubs);
        }
        //-------------------------------------------------------------------------------------------------------


        //*******************************************Remove one***********************************
        // remove skills 
        public ActionResult RemoveSkills(int skillId)
        {
            searchSkills.Remove(searchSkills.Where(s => s.ID == skillId).FirstOrDefault());
            return PartialView("_SkillsFilter", searchSkills);
        }

        // remove tracks 
        public ActionResult RemoveTracks(int trackId)
        {
            searchTracks.Remove(searchTracks.Where(s => s.ID == trackId).FirstOrDefault());
            return PartialView("_TracksFilter", searchTracks);
        }
        // remove subs 
        public ActionResult RemoveSubs(int subId)
        {
            searchSubs.Remove(searchSubs.Where(s => s.ID == subId).FirstOrDefault());
            return PartialView("_SubsFilter", searchSubs);
        }
        //---------------------------------------------------------------------------------------------------------------


        //*******************************************Remove All***************************************
        // all skills 
        public JsonResult RemoveAllSkills()      // in order for ajax to understand that we are returning objects we use Json Result
        {
            try
            {
                searchSkills = new List<Skill>();
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("", MediaTypeNames.Text.Plain);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed, please try again", MediaTypeNames.Text.Plain);
            }

        }

        // all tracks
        public JsonResult RemoveAllTracks()      // in order for ajax to understand that we are returning objects we use Json Result
        {
            try
            {
                searchTracks = new List<Track>();
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("", MediaTypeNames.Text.Plain);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed, please try again", MediaTypeNames.Text.Plain);
            }

        }
        // all subs 
        public JsonResult RemoveAllSubs()      // in order for ajax to understand that we are returning objects we use Json Result
        {
            try
            {
                searchSubs = new List<Subsidary>();
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("", MediaTypeNames.Text.Plain);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed, please try again", MediaTypeNames.Text.Plain);
            }

        }
        //-------------------------------------------------------------------------------------------------------------


        // ********************************************Find function*****************************

        //find skills
        public ActionResult Find(bool checkbox)
        {
            if (searchSkills.Count != 0)
            {
                var skillids = searchSkills.Select(n => n.ID).ToList(); //skills ids
                var skills = searchSkills;

                var empskill = (from d in db.EmpSkills //employee ids
                                select d);
                var emsk = db.EmpSkills.Select(n => n.EmpID).ToList();

                List<IGrouping<int, EmpSkill>> EmpGroupedSkills = null;
                if (checkbox == true)
                {
                }

                List<EmpSkill> results = new List<EmpSkill>();
                //select all empid with any skillid
                foreach (int id in skillids)
                {
                    var result = empskill.Where(t => t.SkillD == id);
                    results.AddRange(result);
                }

                EmpGroupedSkills = results.GroupBy(x => x.EmpID).ToList();

                List<EmpResultModel> list = new List<EmpResultModel>();
                foreach (var item in EmpGroupedSkills)
                {
                    Employee emp = db.Employees.Where(c => c.ID == item.Key).FirstOrDefault();
                    double matchedSkillsPercentage = ((double)item.Count() / (double)skillids.Count) * 100;
                    matchedSkillsPercentage = Math.Round(matchedSkillsPercentage);

                    if (checkbox == true)
                    {
                        if (matchedSkillsPercentage >= 100)
                        {
                            list.Add(new EmpResultModel(matchedSkillsPercentage, emp));
                        }
                    }
                    else
                    {
                        list.Add(new EmpResultModel(matchedSkillsPercentage, emp));
                    }
                }

                return PartialView("_Search", list);
            }
            else
            {
                return Content("<h2>No Search Criteria!</h2>");
            }
        }

        //find tracks
        public ActionResult FindTrack(int skillLevel)
        {
            if (searchTracks.Count != 0)
            {
                var tracksids = searchTracks.Select(n => n.ID);

                var trackskills = (from d in db.TrackSkills //employee ids
                                   select d
                                   );

                // Group Emp Skills by employee
                // For each loop on each group ( per employee)
                // For each loop on the slected tracks
                // Get emp skills where track id = current track
                // if !(count of both list is equal && min level >= selected level)
                //  Break;
                // Add employee to employees list

                List<int> skillids = null;
                var result = new List<int>();
                foreach (int item in tracksids)
                {
                    result.AddRange(trackskills.Where(t => t.TrackID == item).Select(t => t.SkillD).ToList());
                    skillids = result;
                }

                if (skillids.Count != 0)
                {

                    var empskill = (from d in db.EmpSkills //employee ids
                                    select d);

                    List<Employee> results = new List<Employee>();
                    foreach (int item in skillids)
                    {
                        var empskills = empskill.Where(t => t.SkillD == item && t.SkillLevel.ID >= skillLevel).Select(t => t.Employee).ToList(); //Minimum skill level condition 
                        foreach (var emp in empskills)
                        {
                            if (results.Where(e => e.ID == emp.ID).FirstOrDefault() == null)
                            {
                                results.Add(emp);
                            }
                        }
                    }

                    return PartialView("_EmpView", results);
                }
                else
                {
                    return Content("<h2>This Track Doesn't Contain Any Skills!</h2>");
                }
            }
            else
            {
                return Content("<h2>No Search Criteria!</h2>");
            }
        }
        // Search For Subs
        public ActionResult FindSub()
        {
            if (searchSubs.Count != 0)
            {
                var subsids = searchSubs.Select(n => n.ID);

                var empsub = (from d in db.EmpSubsidaries //employee ids
                              select d);

                List<Employee> results = new List<Employee>();
                foreach (int item in subsids)
                {
                    var subEmployees = empsub.Where(t => t.SubsidaryID == item).Select(t => t.Employee).ToList();
                    foreach (var emp in subEmployees)
                    {
                        if (results.Where(e => e.ID == emp.ID).FirstOrDefault() == null)
                        {
                            results.Add(emp);
                        }
                    }
                }
                if (results.Count != 0)
                {
                    return PartialView("_EmpView", results);
                }
                else
                {
                    return Content("<h2>No Employees Found!</h2>");
                }
            }
            else
            {
                return Content("<h2>No Search Criteria!</h2>");
            }

        }



        //--------------------------------------------------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        // Find tracks attempt 
        //find tracks
        public ActionResult FindTrackTest(int skillLevel)
        {
            if (searchTracks.Count != 0)
            {
                var EmpSkill = (from es in db.EmpSkills
                                select es);
                List<IGrouping<int, EmpSkill>> EmpGroupedSkills = null;
                EmpGroupedSkills = EmpSkill.GroupBy(x => x.EmpID).ToList();
                List<SkillLevel> levels = db.SkillLevels.ToList();

                // Group Emp Skills by employee
                // For each loop on each group ( per employee)
                // For each loop on the slected tracks
                // Get emp skills where track id = current track
                // if !(count of both list is equal && min level >= selected level)
                //  Break;
                // Add employee to employees list

                bool add = false;
                List<Employee> results = new List<Employee>();
                foreach (var item in EmpGroupedSkills)
                {
                    foreach (var tr in searchTracks)
                    {
                        var trackskills = db.TrackSkills.Where(t => t.TrackID == tr.ID);
                        foreach(var sk in trackskills)
                        {
                            if (item.Where(e => e.SkillD == sk.SkillD).FirstOrDefault() == null
                                || Convert.ToInt32(item.Where(e => e.SkillD == sk.SkillD).FirstOrDefault().SkillLevel.Name) <
                                Convert.ToInt32(levels.Where(l => l.ID == skillLevel).FirstOrDefault().Name))
                            {
                                add = false;
                                break;
                            }
                            else { add = true; }
                        }
                        if (!add) break;
                    }
                    if(add)
                    {
                        results.Add(db.Employees.Where(e => e.ID == item.Key).FirstOrDefault());
                    }
                }
                // if true add employee
                if (results.Count() >= 1)
                {
                    return PartialView("_EmpView", results);
                }

                else
                {
                    return Content("<h2>This Track Doesn't Contain Any Skills!</h2>");
                }
            }
            return Content("<h2>This Track Doesn't Contain Any Skills!</h2>");
        }
    }
}
