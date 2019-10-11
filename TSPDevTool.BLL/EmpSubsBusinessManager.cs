using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class EmpSubsBusinessManager
    {
        EmpSubsDataManager empsubsdatamanager;

        public EmpSubsBusinessManager(TSPEntities dbconn)
        {
            empsubsdatamanager = new EmpSubsDataManager(dbconn);
        }

        public EmpSubsidary GetById(int id)
        {
            return empsubsdatamanager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            empsubsdatamanager.DeleteById(id);
        }
        public EmpSubsidary Add(EmpSubsidary emp)
        {
            return empsubsdatamanager.Add(emp);
        }
        public EmpSubsidary Update(EmpSubsidary emp)
        {
            return empsubsdatamanager.Update(emp);
        }
        public List<EmpSubsidary> GetAll()
        {
            return empsubsdatamanager.GetAll();
        }
        public List<EmpSubsidary> GetByEmployeeID(int id)
        {
            return empsubsdatamanager.GetByEmployeeID(id);
        }

        public void deleteSubsidiariesByEmployeeId(int id)
        {

            empsubsdatamanager.deleteSubsidiariesByEmployeeId(id);

        }


    }
}
