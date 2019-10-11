using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class EmpSkillBusinessManager
    {
        EmpSkillDataManager empskilldatamanager;

        public EmpSkillBusinessManager(TSPEntities dbconn)
        {
            empskilldatamanager = new EmpSkillDataManager(dbconn);
        }

        public EmpSkill GetById(int id)
        {
            return empskilldatamanager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            empskilldatamanager.DeleteById(id);
        }
        public EmpSkill Add(EmpSkill emp)
        {
            return empskilldatamanager.Add(emp);
        }
        public EmpSkill Update(EmpSkill emp)
        {
            return empskilldatamanager.Update(emp);
        }
        public List<EmpSkill> GetAll()
        {
            return empskilldatamanager.GetAll();
        }
        public List<EmpSkill> GetByEmployeeID(int id)
        {
            return empskilldatamanager.GetByEmployeeID(id);
        }

        public void deleteSkillByEmployeeID(int id)
        {

            empskilldatamanager.deleteSkillsByEmployeeID(id);

        }


    }
}
