using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TSPDevTool.BLL;
using TSPDevTools.Model;

namespace TSPDevTool.UI.Controllers
{
    [Authorize(Users = "test")]
    public class SubsidariesController : Controller
    {
        private TSPEntities db = new TSPEntities();
        SubsidariesBusinessManager subsidariesBusinessManager;

        public SubsidariesController()
        {
            db = new TSPEntities();
            subsidariesBusinessManager = new SubsidariesBusinessManager(db);
        }

        // GET: Subsidaries
        public ActionResult Index()
        {
            return View(subsidariesBusinessManager.GetAll());
        }

        // GET: Subsidaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subsidary subsidary = subsidariesBusinessManager.GetById(id.Value);
            if (subsidary == null)
            {
                return HttpNotFound();
            }
            return View(subsidary);
        }

        // GET: Subsidaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subsidaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Subsidary subsidary)
        {
            if (ModelState.IsValid)
            {
                subsidariesBusinessManager.Add(subsidary);
                return RedirectToAction("Index");
            }

            return View(subsidary);
        }

        // GET: Subsidaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subsidary subsidary = subsidariesBusinessManager.GetById(id.Value);
            if (subsidary == null)
            {
                return HttpNotFound();
            }
            return View(subsidary);
        }

        // POST: Subsidaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Subsidary subsidary)
        {
            if (ModelState.IsValid)
            {
                subsidariesBusinessManager.Update(subsidary);
            }
            return View(subsidary);
        }

        // GET: Subsidaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subsidary subsidary = subsidariesBusinessManager.GetById(id.Value);
            if (subsidary == null)
            {
                return HttpNotFound();
            }
            return View(subsidary);
        }

        // POST: Subsidaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subsidariesBusinessManager.Deletebyid(id);
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
