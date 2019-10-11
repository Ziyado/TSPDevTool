using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTools.Model;

namespace TSPDevTool.DAL
{
    public class SkillsDataManager
    {

        TSPEntities dbconn;
        public SkillsDataManager(TSPEntities dbconn)
        {
            this.dbconn = dbconn;
        }

        public Skill GetById(int id)
        {
            Skill sk = dbconn.Skills.Where(e => e.ID == id).FirstOrDefault();
            return sk;
        }
        public void DeleteById(int id)
        {

            Skill sk = GetById(id);
            dbconn.Skills.Remove(sk);
            dbconn.SaveChanges();


        }

        public Skill Add(Skill sk)
        {
            Skill addedSkill = dbconn.Skills.Add(sk);

            dbconn.SaveChanges();

            return addedSkill;
        }
        public Skill Update(Skill sk)
        {
            dbconn.Entry(sk).State = EntityState.Modified;
            dbconn.SaveChanges();
            return sk;
        }
        public List<Skill> GetAll()
        {
            List<Skill> sk = dbconn.Skills.ToList();
            return sk;
        }


        public List<Skill> GetUnmappedSkillsByEmpId(int? empId)
        {
            List<Skill> sk = dbconn.GetUnmappedSkillsByEmpId(empId).ToList();
            return sk;
        }
        public List<Skill> GetUnmappedSkillsByTrackId(int? trId)
        {
            List<Skill> sk = dbconn.GetUnmappedSkillsByTrackId(trId).ToList();
            return sk;
        }
    }
}

