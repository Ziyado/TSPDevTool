using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class SkillsBusinessManager
    {
        SkillsDataManager skillDataManager;

        public SkillsBusinessManager(TSPEntities dbconn)
        {
            skillDataManager = new SkillsDataManager(dbconn);
        }

        public Skill GetById(int id)
        {
            return skillDataManager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            skillDataManager.DeleteById(id);
        }
        public Skill Add(Skill sk)
        {
            return skillDataManager.Add(sk);
        }
        public Skill Update(Skill sk)
        {
            return skillDataManager.Update(sk);
        }
        public List<Skill> GetAll()
        {
            return skillDataManager.GetAll();
        }
        public List<Skill> GetUnmappedSkillsByEmpId(int? empId)
        {
            return skillDataManager.GetUnmappedSkillsByEmpId(empId);
        }
        public List<Skill> GetUnmappedSkillsByTrackId(int? trId)
        {
            return skillDataManager.GetUnmappedSkillsByTrackId(trId);
        }

    }
}
