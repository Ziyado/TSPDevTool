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
    public class TracksController : Controller
    {
        private TSPEntities db;
        // Creating Objects from the BLL 
        TracksBusinessManager tracksBusinessManager;
        EmployeeBusinessManager employeeBusinessManager;
        RoleBusinessManager roleBusinessManager;
        WorkloadBusinessManager workloadbusinessManager;
        SkillsBusinessManager skillsbusinessManager;
        EmpSkillBusinessManager empskilssbusinessManager;
        SkillLevelsBusinessManager skilllevelbusinessManager;
        SubsidariesBusinessManager subsidiariesbusinessManager;
        EmpSubsBusinessManager empSubsBusinessManager;
        TrackSkillsBusinessManager trackskillsbusinessManager;

        public TracksController()
        {
            db = new TSPEntities();
            tracksBusinessManager = new TracksBusinessManager(db);
            employeeBusinessManager = new EmployeeBusinessManager(db);
            roleBusinessManager = new RoleBusinessManager(db);
            workloadbusinessManager = new WorkloadBusinessManager(db);
            skillsbusinessManager = new SkillsBusinessManager(db);
            empskilssbusinessManager = new EmpSkillBusinessManager(db);
            skilllevelbusinessManager = new SkillLevelsBusinessManager(db);
            subsidiariesbusinessManager = new SubsidariesBusinessManager(db);
            empSubsBusinessManager = new EmpSubsBusinessManager(db);
            trackskillsbusinessManager = new TrackSkillsBusinessManager(db);
        }

        // GET: Tracks
        public ActionResult Index()
        {
            var tracks = db.Tracks.Include(t => t.Workload);
            return View(tracksBusinessManager.GetAll());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = tracksBusinessManager.GetById(id.Value);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            ViewBag.WorkloadID = new SelectList(tracksBusinessManager.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,WorkloadID")] Track track)
        {
            if (ModelState.IsValid)
            {
                tracksBusinessManager.Add(track);
                return RedirectToAction("Index");
            }

            ViewBag.WorkloadID = new SelectList(db.Workloads, "ID", "Name", track.WorkloadID);
            return View(track);
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = tracksBusinessManager.GetById(id.Value);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkloadID = new SelectList(db.Workloads, "ID", "Name", track.WorkloadID);
            return View("Edit", track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,WorkloadID")] Track track)
        {
            if (ModelState.IsValid)
            {
                tracksBusinessManager.Update(track);
                return RedirectToAction("Index");
            }
            ViewBag.WorkloadID = new SelectList(db.Workloads, "ID", "Name", track.WorkloadID);
            return View(track);
        }
        //// Add Skills 
        public ActionResult AddSkills(int skillId, int trackId) // ID of track
        {
            var trackSkill = new TrackSkill();
            trackSkill.TrackID = trackId;
            List<Skill> skills = skillsbusinessManager.GetUnmappedSkillsByTrackId(trackId);
            if (skills.Where(s => s.ID == skillId).FirstOrDefault() != null)
            {
                trackSkill.SkillD = skillId;
                trackskillsbusinessManager.Add(trackSkill);
            }
            var trackSkills = trackskillsbusinessManager.GetByTrackID(trackId);
            return PartialView("_trackSkills", trackSkills);

        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = tracksBusinessManager.GetById(id.Value);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tracksBusinessManager.Deletebyid(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


                                                            // Json Functions 

        // Autocomplete 

        public JsonResult GetAutoSkills(string Prefix, int trackId)
        {
            List<Skill> result;
            if (string.IsNullOrEmpty(Prefix))
            {
                result = skillsbusinessManager.GetUnmappedSkillsByTrackId(trackId);
            }
            else
            {
                result = skillsbusinessManager.GetUnmappedSkillsByTrackId(trackId);
                result = result.Where(s => s.Name.ToLower().Contains(Prefix.ToLower())).ToList();
            }

            var translatedResult = SkillModel.Translate(result); // to avoid circular reference 
            return Json(translatedResult, JsonRequestBehavior.AllowGet);

        }
        // Delete track skills 
        public JsonResult DeleteTrackSkill(int TrackSkillId) //ID of skill 
        {

            try
            {
                trackskillsbusinessManager.Deletebyid(TrackSkillId);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("", MediaTypeNames.Text.Plain);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed, please try again", MediaTypeNames.Text.Plain);
            }

        }
        // Remove All 
        public JsonResult deleteAllTrackSkills(int trackId)
        {
            try
            {
                trackskillsbusinessManager.deleteSkillsByTrackID(trackId);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("", MediaTypeNames.Text.Plain);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed, please try again", MediaTypeNames.Text.Plain);
            }
        }
        // Adding a new skill not in the database 
        public ActionResult AddNewSkill(int trackId, string skill)
        {
            var trackSkill = new TrackSkill();
            Skill NewSkill = new Skill();
            NewSkill.Name = skill;
            var added = skillsbusinessManager.Add(NewSkill);
            trackSkill.TrackID = trackId;
            List<Skill> skills = skillsbusinessManager.GetUnmappedSkillsByTrackId(trackId);
            if (skills.Where(j => j.ID == added.ID).FirstOrDefault() != null)
            {
                trackSkill.SkillD = added.ID;
                trackskillsbusinessManager.Add(trackSkill);
            }
            var trackSkills = trackskillsbusinessManager.GetByTrackID(trackId);
            return PartialView("_trackSkills", trackSkills);
        }
       
    }
}
