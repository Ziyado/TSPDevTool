using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using TSPDevTools.Model;

namespace TSPDevTool.DAL
{
    public class EmpSkillDataManager          // The Class
    {
        TSPEntities dbconn;

        public EmpSkillDataManager(TSPEntities dbconn)       // Constructor for db connection 
        {
            this.dbconn = dbconn;
        }

        public EmpSkill GetById(int id)          // Get the ID Function 
        {
            EmpSkill emp = dbconn.EmpSkills.Where(e => e.ID == id).FirstOrDefault();
            return emp;
        }
        public void DeleteById(int id)           // Delete function 
        {

            EmpSkill emp = GetById(id);
            dbconn.EmpSkills.Remove(emp);
            dbconn.SaveChanges();
        }

        public EmpSkill Add(EmpSkill emp)      // Adding Function 
        {
            EmpSkill addedEmp = dbconn.EmpSkills.Add(emp);
            dbconn.SaveChanges();

            return addedEmp;
        }
        public EmpSkill Update(EmpSkill emp)    // Update Function 
        {

            dbconn.Entry(emp).State = EntityState.Modified;
            dbconn.SaveChanges();
            return emp;
        }
        public List<EmpSkill> GetAll()
        {
            List<EmpSkill> emp = dbconn.EmpSkills.ToList();
            return emp;
        }
        public List<EmpSkill> GetByEmployeeID(int id)
        {
            List<EmpSkill> emsk = dbconn.EmpSkills.Where(v => v.EmpID == id).Include("Skill").Include("SkillLevel").ToList(); //the Include() resolved the problem of double click 

            return emsk;
        }

        //Deletes all the employee skills
        public void deleteSkillsByEmployeeID(int id)
        {   
            List<EmpSkill> delete = dbconn.EmpSkills.Where(v => v.EmpID == id).ToList();
            foreach (var item in delete)
            {
                dbconn.EmpSkills.Remove(item);
                dbconn.SaveChanges();
            }

            var variable = dbconn.EmpSkills.Where(v => v.EmpID == id).ToList();
        }

        ////Deletes all the employee skills
        //public void getAllSkillsByEmpId(int id)
        //{
        //    List<EmpSkill> skills = dbconn.EmpSkills.Where(v => v.EmpID == id).ToList();

        //   foreach (var item in skills)
        //    {
                
        //        double value = (Convert.ToInt32(item.SkillLevel)* 100) / 360;
        //                color: "teal",
        //                highlight: "black",
        //                label: "Javascript"
        //    }

        //}
        



    }
}

