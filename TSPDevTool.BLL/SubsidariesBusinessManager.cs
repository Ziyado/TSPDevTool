using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class SubsidariesBusinessManager
    {
        SubsidariesDataManager subsidariesDataManager;

        public SubsidariesBusinessManager(TSPEntities dbconn)
            {
            subsidariesDataManager = new SubsidariesDataManager(dbconn);
        }

        public Subsidary GetById(int id)
        {
            return subsidariesDataManager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            subsidariesDataManager.DeleteById(id);
        }
        public Subsidary Add(Subsidary sub)
        {
            return subsidariesDataManager.Add(sub);
        }
        public Subsidary Update(Subsidary sub)
        {
            return subsidariesDataManager.Update(sub);
        }
        public List<Subsidary> GetAll()
        {
            return subsidariesDataManager.GetAll();
        }
        public List<Subsidary> GetUnmappedSubsidiariesByEmpID(int? empId)
        {
            return subsidariesDataManager.GetUnmappedSubsidiariesByEmpID(empId);
        }

    }
}