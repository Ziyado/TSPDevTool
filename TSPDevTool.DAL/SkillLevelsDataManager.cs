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
    public class SkillLevelsDataManager           // The Class
    {
        TSPEntities dbconn;

        public SkillLevelsDataManager(TSPEntities dbconn)       // Constructor for db connection 
        {
            this.dbconn = dbconn;
        }

        public SkillLevel GetById(int id)          // Get the ID Function 
        {
            SkillLevel emp = dbconn.SkillLevels.Where(e => e.ID == id).FirstOrDefault();
            return emp;
        }
        public void DeleteById(int id)           // Delete function 
        {

            SkillLevel emp = GetById(id);
            dbconn.SkillLevels.Remove(emp);
            dbconn.SaveChanges();
        }

        public SkillLevel Add(SkillLevel emp)      // Adding Function 
        {
            SkillLevel addedEmp = dbconn.SkillLevels.Add(emp);
            dbconn.SaveChanges();

            return addedEmp;
        }
        public SkillLevel Update(SkillLevel emp)    // Update Function 
        {

            dbconn.Entry(emp).State = EntityState.Modified;
            dbconn.SaveChanges();
            return emp;
        }
        public List<SkillLevel> GetAll()
        {
            List<SkillLevel> sk = dbconn.SkillLevels.ToList();
            return sk;
        }
    }
}

