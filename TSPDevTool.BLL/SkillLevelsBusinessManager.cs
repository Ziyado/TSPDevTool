using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class SkillLevelsBusinessManager  
    {
        SkillLevelsDataManager skillLevelsDataManager;

        public SkillLevelsBusinessManager(TSPEntities dbconn)
        {
            skillLevelsDataManager = new SkillLevelsDataManager(dbconn);
        }
        public SkillLevel Getbyid(int id)
        {
            return skillLevelsDataManager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            skillLevelsDataManager.DeleteById(id);
        }
        public SkillLevel Add(SkillLevel skl)
        {
            return skillLevelsDataManager.Add(skl);
        }
        public SkillLevel Update(SkillLevel skl)
        {
            return skillLevelsDataManager.Update(skl);
        }
        public List<SkillLevel> GetAll()
        {
            return skillLevelsDataManager.GetAll();
        }
    }
}
