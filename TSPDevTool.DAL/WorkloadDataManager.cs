using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using TSPDevTools.Model;

namespace TSPDevTool.DAL
{
    public class WorkloadDataManager
    {
        TSPEntities dbconn;

        public WorkloadDataManager(TSPEntities dbconn)
        {
            this.dbconn = dbconn;
        }

        public Workload GetById(int id)
        {
            Workload emp = dbconn.Workloads.Where(e => e.ID == id).FirstOrDefault();
            return emp;
        }
        public void DeleteById(int id)
        {

            Workload emp = GetById(id);
            dbconn.Workloads.Remove(emp);
            dbconn.SaveChanges();
        }

        public Workload Add(Workload emp)
        {
            Workload addedEmp = dbconn.Workloads.Add(emp);
            dbconn.SaveChanges();

            return addedEmp;
        }
        public Workload Update(Workload emp)
        {

            dbconn.Entry(emp).State = EntityState.Modified;
            dbconn.SaveChanges();
            return emp;
        }

        public List<Workload> GetAll()
        {
            List<Workload> list = dbconn.Workloads.ToList();

            return list;
        }
    }
}
