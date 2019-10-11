using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class WorkloadBusinessManager
    {
        WorkloadDataManager workloadDataManager;

       public WorkloadBusinessManager(TSPEntities dbconn)
        {
            workloadDataManager = new WorkloadDataManager(dbconn);
        }
       
        public Workload GetById(int id) {
            return workloadDataManager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            workloadDataManager.DeleteById(id);
        }
        public Workload Add(Workload wl)
        {
            return workloadDataManager.Add(wl);
        }
        public Workload Update(Workload wl)
        {
            return workloadDataManager.Update(wl);
        }

        public List<Workload> GetAll()
        {
            return workloadDataManager.GetAll();
        }

        public Workload Deletebyid(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
