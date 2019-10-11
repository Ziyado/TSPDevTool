using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TSPDevTools.Model;
using TSPDevTool.BLL;

namespace TSPDevTool.UI.Controllers
{
    [Authorize(Users = "test")]
    public class SkillLevelsController : Controller
    {
        private TSPEntities db = new TSPEntities();
        SkillLevelsBusinessManager skilllevelBusinessManager;

        public SkillLevelsController()
        {
            db = new TSPEntities();
            skilllevelBusinessManager = new SkillLevelsBusinessManager(db);
        }

        // GET: SkillLevels
        public ActionResult Index()
        {
            return View(skilllevelBusinessManager.GetAll());
        }

        // GET: SkillLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillLevel skillLevel = skilllevelBusinessManager.Getbyid(id.Value);
            if (skillLevel == null)
            {
                return HttpNotFound();
            }
            return View(skillLevel);
        }

        // GET: SkillLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] SkillLevel skillLevel)
        {
            if (ModelState.IsValid)
            {
                skilllevelBusinessManager.Add(skillLevel);
                return RedirectToAction("Index");
            }

            return View(skillLevel);
        }

        // GET: SkillLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillLevel skillLevel = skilllevelBusinessManager.Getbyid(id.Value);
            if (skillLevel == null)
            {
                return HttpNotFound();
            }
            return View(skillLevel);
        }

        // POST: SkillLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] SkillLevel skillLevel)
        {
            if (ModelState.IsValid)
            {
                skilllevelBusinessManager.Update(skillLevel);
            }
            return View(skillLevel);
        }

        // GET: SkillLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillLevel skillLevel = skilllevelBusinessManager.Getbyid(id.Value);
            if (skillLevel == null)
            {
                return HttpNotFound();
            }
            return View(skillLevel);
        }

        // POST: SkillLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skilllevelBusinessManager.Deletebyid(id);
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
    }
}
