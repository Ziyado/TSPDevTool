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
    public class EmpSubsDataManager          // The Class
    {
        TSPEntities dbconn;

        public EmpSubsDataManager(TSPEntities dbconn)       // Constructor for db connection 
        {
            this.dbconn = dbconn;
        }

        public EmpSubsidary GetById(int id)          // Get the ID Function 
        {
            EmpSubsidary emp = dbconn.EmpSubsidaries.Where(e => e.ID == id).FirstOrDefault();
            return emp;
        }
        public void DeleteById(int id)           // Delete function 
        {

            EmpSubsidary emp = GetById(id);
            dbconn.EmpSubsidaries.Remove(emp);
            dbconn.SaveChanges();
        }

        public EmpSubsidary Add(EmpSubsidary emp)      // Adding Function 
        {
            EmpSubsidary addedEmp = dbconn.EmpSubsidaries.Add(emp);
            dbconn.SaveChanges();

            return addedEmp;
        }
        public EmpSubsidary Update(EmpSubsidary emp)    // Update Function 
        {

            dbconn.Entry(emp).State = EntityState.Modified;
            dbconn.SaveChanges();
            return emp;
        }
        public List<EmpSubsidary> GetAll()
        {
            List<EmpSubsidary> emp = dbconn.EmpSubsidaries.ToList();
            return emp;
        }
        public List<EmpSubsidary> GetByEmployeeID(int id)
        {
            List<EmpSubsidary> emsk = dbconn.EmpSubsidaries.Where(v => v.EmpID == id).Include("Subsidary").ToList(); //the Include() resolved the problem of double click 

            return emsk;
        }

        //Deletes all the employee subsidiaries
        public void deleteSubsidiariesByEmployeeId(int id)
        {
            List<EmpSubsidary> delete = dbconn.EmpSubsidaries.Where(v => v.EmpID == id).ToList();
            foreach (var item in delete)
            {
                dbconn.EmpSubsidaries.Remove(item);
                dbconn.SaveChanges();
            }

            var variable = dbconn.EmpSubsidaries.Where(v => v.EmpID == id).ToList();
        }

    }
}

