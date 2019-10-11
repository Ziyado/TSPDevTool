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
    public class WorkloadsController : Controller
    {
        private TSPEntities db = new TSPEntities();
        WorkloadBusinessManager workloadBusinessManager;

        public WorkloadsController()
        {
            db = new TSPEntities();
            workloadBusinessManager = new WorkloadBusinessManager(db);
        }

        // GET: Workloads
        public ActionResult Index()
        {
            return View(workloadBusinessManager.GetAll());
        }

        // GET: Workloads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Workload workload = workloadBusinessManager.GetById(id.Value);
            if (workload == null)
            {
                return HttpNotFound();
            }
            return View(workload);
        }

        // GET: Workloads/Create
        public ActionResult Create()
        {       
                ViewBag.WorkloadID = new SelectList(workloadBusinessManager.GetAll(), "ID", "Name");
                return View();
            }

        // POST: Workloads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Workload workload)
        {
            if (ModelState.IsValid)
            {
                workloadBusinessManager.Add(workload);
                return RedirectToAction("Index");
            }

            return View(workload);
        }

        // GET: Workloads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workload workload = workloadBusinessManager.GetById(id.Value);
            if (workload == null)
            {
                return HttpNotFound();
            }
            return View(workload);
        }

        // POST: Workloads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Workload workload)
        {
            if (ModelState.IsValid)
            {
                workloadBusinessManager.Update(workload);
            }
            return View(workload);
        }

        // GET: Workloads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workload workload = workloadBusinessManager.GetById(id.Value);
            if (workload == null)
            {
                return HttpNotFound();
            }
            return View(workload);
        }

        // POST: Workloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            workloadBusinessManager.Deletebyid(id);
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
