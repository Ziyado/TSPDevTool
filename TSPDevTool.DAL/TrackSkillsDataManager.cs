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
    public class TrackSkillsDataManager          // The Class
    {
        TSPEntities dbconn;

        public TrackSkillsDataManager(TSPEntities dbconn)       // Constructor for db connection 
        {
            this.dbconn = dbconn;
        }

        public TrackSkill GetById(int id)          // Get the ID Function 
        {
            TrackSkill emp = dbconn.TrackSkills.Where(e => e.ID == id).FirstOrDefault();
            return emp;
        }
        public void DeleteById(int id)           // Delete function 
        {

            TrackSkill emp = GetById(id);
            dbconn.TrackSkills.Remove(emp);
            dbconn.SaveChanges();
        }

        public TrackSkill Add(TrackSkill emp)      // Adding Function 
        {
            TrackSkill addedEmp = dbconn.TrackSkills.Add(emp);
            dbconn.SaveChanges();

            return addedEmp;
        }
        public TrackSkill Update(TrackSkill emp)    // Update Function 
        {

            dbconn.Entry(emp).State = EntityState.Modified;
            dbconn.SaveChanges();
            return emp;
        }
        public List<TrackSkill> GetAll()
        {
            List<TrackSkill> emp = dbconn.TrackSkills.ToList();
            return emp;
        }
        public List<TrackSkill> GetByTrackID(int id)
        {
            List<TrackSkill> emsk = dbconn.TrackSkills.Where(v => v.TrackID == id).Include("Skill").ToList(); //the Include() resolved the problem of double click 

            return emsk;
        }

        //Deletes all the employee skills
        public void deleteSkillsByTrackID(int id)
        {
            List<TrackSkill> delete = dbconn.TrackSkills.Where(v => v.TrackID == id).ToList();
            foreach (var item in delete)
            {
                dbconn.TrackSkills.Remove(item);
                dbconn.SaveChanges();
            }

            var variable = dbconn.TrackSkills.Where(v => v.TrackID == id).ToList();
        }

    }
}

