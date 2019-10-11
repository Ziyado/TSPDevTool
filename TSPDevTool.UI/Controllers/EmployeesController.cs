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
using System.Reflection;

namespace TSPDevTool.UI.Controllers
{
    [Authorize(Users = "test")]
    public class EmployeesController : Controller
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


        public EmployeesController()
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
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View(employeeBusinessManager.GetAll());
        }
        public ActionResult SearchByJoiningDate()
        {
            return View(employeeBusinessManager.GetAll());
        }

        public ActionResult SearchbyRole()
        {
            return View(employeeBusinessManager.GetAll());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeBusinessManager.GetById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(employeeBusinessManager.GetAll(), "ID", "Name");
            ViewBag.RoleID = new SelectList(roleBusinessManager.GetAll(), "ID", "Name");
            ViewBag.WorkloadID = new SelectList(workloadbusinessManager.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,RoleID,Alias,WorkloadID,JoiningDate,ManagerID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBusinessManager.Add(employee);
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(employeeBusinessManager.GetAll(), "ID", "Name", employee.ManagerID);
            ViewBag.RoleID = new SelectList(roleBusinessManager.GetAll(), "ID", "Name", employee.RoleID);
            ViewBag.WorkloadID = new SelectList(workloadbusinessManager.GetAll(), "ID", "Name", employee.WorkloadID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeBusinessManager.GetById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(employeeBusinessManager.GetAll(), "ID", "Name", employee.ManagerID);
            ViewBag.RoleID = new SelectList(roleBusinessManager.GetAll(), "ID", "Name", employee.RoleID);
            ViewBag.WorkloadID = new SelectList(workloadbusinessManager.GetAll(), "ID", "Name", employee.WorkloadID);
            ViewBag.SkillLevel = new SelectList(skilllevelbusinessManager.GetAll(), "ID", "Name");
            ViewBag.Subsidiary = new SelectList(subsidiariesbusinessManager.GetAll(), "ID", "Name");
            return View("Edit",employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,RoleID,Alias,WorkloadID,JoiningDate,ManagerID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBusinessManager.Update(employee);
            }

            employee = employeeBusinessManager.GetById(employee.ID);
            ViewBag.ManagerID = new SelectList(employeeBusinessManager.GetAll(), "ID", "Name", employee.ManagerID);
            ViewBag.RoleID = new SelectList(roleBusinessManager.GetAll(), "ID", "Name", employee.RoleID);
            ViewBag.WorkloadID = new SelectList(workloadbusinessManager.GetAll(), "ID", "Name", employee.WorkloadID);
            ViewBag.SkillLevel = new SelectList(skilllevelbusinessManager.GetAll(), "ID", "Name");
            ViewBag.Subsidiary = new SelectList(subsidiariesbusinessManager.GetAll(), "ID", "Name");
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeBusinessManager.GetById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeBusinessManager.Deletebyid(id);
            return RedirectToAction("Index");
        }
        // Add Skills 
        public ActionResult AddSkills(int skillId, int empId, int skillLevelId) // ID of skill 
        {
            var empSkill = new EmpSkill();
            empSkill.EmpID = empId;
            List<Skill> skills = skillsbusinessManager.GetUnmappedSkillsByEmpId(empId);
            if (skills.Where(s=> s.ID == skillId).FirstOrDefault() != null)
            {
                empSkill.SkillD = skillId;
                empSkill.SkillLevelID = skillLevelId;
                empskilssbusinessManager.Add(empSkill);
            }
            var empSkills = empskilssbusinessManager.GetByEmployeeID(empId);
            return PartialView("_userSkills", empSkills);

        }
                                                    // Add Subsidiary 

        public ActionResult AddSubsidiary(int subId, int empId) //Add Subsidiary to database
        {
            var EmpSub = new EmpSubsidary();
            EmpSub.EmpID = empId;
            List<Subsidary> subs = subsidiariesbusinessManager.GetUnmappedSubsidiariesByEmpID(empId);
            if (subs.Where(s => s.ID == subId).FirstOrDefault() != null)
            {
                EmpSub.SubsidaryID = subId;
                empSubsBusinessManager.Add(EmpSub);
            }
            var EmpSubs = empSubsBusinessManager.GetByEmployeeID(empId);
            return PartialView("_UserSubs", EmpSubs); // View to return data to

        }

        public JsonResult GetSkillLevels()
        {
            List<String> result = db.SkillLevels.Select(r => r.Name).ToList();
            ViewData["skilllevelslist"] = new SelectList(db.SkillLevels, "ID" , "Name");
            return Json(result, JsonRequestBehavior.AllowGet); 

        }

        public JsonResult GetAutoSkills(string Prefix, int empId)
        {
            List<Skill> result;
            if (string.IsNullOrEmpty(Prefix))
            {
                result = skillsbusinessManager.GetUnmappedSkillsByEmpId(empId);
            }
            else
            {
                result = skillsbusinessManager.GetUnmappedSkillsByEmpId(empId);
                result = result.Where(s => s.Name.ToLower().Contains(Prefix.ToLower())).ToList();
            }

            var translatedResult = SkillModel.Translate(result); // to avoid circular reference 
            return Json(translatedResult, JsonRequestBehavior.AllowGet);

        }
        
        public JsonResult DeleteEmpSkill(int EmpSkillId) //ID of skill 
        {

            try
            {
                empskilssbusinessManager.Deletebyid(EmpSkillId);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("", MediaTypeNames.Text.Plain);
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed, please try again", MediaTypeNames.Text.Plain);
            }

        }

        public JsonResult DeleteEmpSub(int EmpSubId) //ID of skill 
        {

            try
            {
                empSubsBusinessManager.Deletebyid(EmpSubId);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("Success", MediaTypeNames.Text.Plain);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed, please try again", MediaTypeNames.Text.Plain);
            }

        }


        public JsonResult deleteAllEmpSkills(int empId)
        {
            try
            {
               empskilssbusinessManager.deleteSkillByEmployeeID(empId);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("", MediaTypeNames.Text.Plain);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed, please try again", MediaTypeNames.Text.Plain);
            }
        }

        public JsonResult deleteAllEmpSubs(int empId)
        {
            try
            {
                empSubsBusinessManager.deleteSubsidiariesByEmployeeId(empId);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("Success", MediaTypeNames.Text.Plain);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed, please try again", MediaTypeNames.Text.Plain);
            }
        }

        // Adding a new skill not in the database 
        public ActionResult AddNewSkill(int empId, int skillLevelId, string skill) 
        {
            var empSkill = new EmpSkill();
            Skill NewSkill = new Skill();
            NewSkill.Name = skill;
            var added = skillsbusinessManager.Add(NewSkill);
            empSkill.EmpID = empId;
            List<Skill> skills = skillsbusinessManager.GetUnmappedSkillsByEmpId(empId);
            if (skills.Where(j => j.ID == added.ID).FirstOrDefault() != null)
            {
                empSkill.SkillD = added.ID;
                empSkill.SkillLevelID = skillLevelId;
                empskilssbusinessManager.Add(empSkill);
            }
            var empSkills = empskilssbusinessManager.GetByEmployeeID(empId);
            return PartialView("_userSkills", empSkills);
        }
         // Get Subsidiaries 
        public JsonResult GetAutoSubs(string Prefix, int empId)      // Subsidiaries List
        {
            List<Subsidary> result;
            if (string.IsNullOrEmpty(Prefix))
            {
                result = subsidiariesbusinessManager.GetUnmappedSubsidiariesByEmpID(empId);
            }
            else
            {
                result = subsidiariesbusinessManager.GetUnmappedSubsidiariesByEmpID(empId);
                result = result.Where(s => s.Name.ToLower().Contains(Prefix.ToLower())).ToList();
            }

            var translatedResult = SubsModel.Translate(result); // to avoid circular reference 
            return Json(translatedResult, JsonRequestBehavior.AllowGet);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
                                            // Adding a new Subsidary not in the database 
        public ActionResult AddNewSubsidary(int empId, string subname)
        {
            var empSub = new EmpSubsidary();
            Subsidary NewSubsidary = new Subsidary();
            NewSubsidary.Name = subname;
            var added = subsidiariesbusinessManager.Add(NewSubsidary);
            empSub.EmpID = empId;
            List<Subsidary> sub = subsidiariesbusinessManager.GetUnmappedSubsidiariesByEmpID(empId);
            if (sub.Where(j => j.ID == added.ID).FirstOrDefault() != null)
            {
                empSub.SubsidaryID = added.ID;
                empSubsBusinessManager.Add(empSub);
            }
            var empSubs = empSubsBusinessManager.GetByEmployeeID(empId);
            return PartialView("_UserSubs", empSubs);
        }

        public ActionResult SearchEmp(string searchstring)      // Subsidiaries List
        {
            List<Employee> result;
         
            if (string.IsNullOrEmpty(searchstring))
            {
                result = employeeBusinessManager.GetAll();
            }
            else
            {
                result = employeeBusinessManager.GetAll();
                result = result.Where(s => s.Name.ToLower().Contains(searchstring.ToLower())).ToList();
            }
            return PartialView("_SearchByEmp", result);
        }

        public ActionResult SearchRole(string searchstring)      
        {
            List<Employee> result;
            if (string.IsNullOrEmpty(searchstring))
            {
                result = employeeBusinessManager.GetAll();
            }
            else
            {
                result = employeeBusinessManager.GetAll();
                result = result.Where(s => s.Role.Name.ToLower().Contains(searchstring.ToLower())).ToList();
            }
            return PartialView("_SearchByEmp", result); 
        }

        public ActionResult SearchDate(DateTime From, DateTime To)
        {
            List<Employee> result;
            if (From == DateTime.MinValue && To == DateTime.MinValue)
            {
                result = employeeBusinessManager.GetAll();
            }
            else
            {
                result = employeeBusinessManager.GetAll();
                result = result.Where(s => s.JoiningDate >= From.Date && s.JoiningDate <= To.Date).ToList();
            }
            return PartialView("_SearchByEmp", result);
        }
        ////public JsonResult getSkillLevels(int empId)
        ////{
        ////    try
        ////    {
        ////        empskilssbusinessManager.getAllSkillsByEmpId(empId);
        ////        Response.StatusCode = (int)HttpStatusCode.OK;
        ////        return Json("Success", MediaTypeNames.Text.Plain);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        ////        return Json("Failed, please try again", MediaTypeNames.Text.Plain);
        ////    }
        ////}
        
    }

}
