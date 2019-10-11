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
    public class SubsidariesDataManager           // The Class
    {
        TSPEntities dbconn;

        public SubsidariesDataManager(TSPEntities dbconn)       // Constructor for db connection 
        {
            this.dbconn = dbconn;
        }

        public Subsidary GetById(int id)          // Get the ID Function 
        {
            Subsidary emp = dbconn.Subsidaries.Where(e => e.ID == id).FirstOrDefault();
            return emp;
        }
         public void DeleteById(int id)           // Delete function 
        {

            Subsidary emp = GetById(id);
            dbconn.Subsidaries.Remove(emp);
            dbconn.SaveChanges();
        }

         public Subsidary Add(Subsidary emp)      // Adding Function 
        {
            Subsidary addedEmp = dbconn.Subsidaries.Add(emp);
            dbconn.SaveChanges();

            return addedEmp;
        }
        public Subsidary Update(Subsidary emp)    // Update Function 
        {

            dbconn.Entry(emp).State = EntityState.Modified;
            dbconn.SaveChanges();
            return emp;
        }

        public List<Subsidary> GetAll()
        { 
            List<Subsidary> list = dbconn.Subsidaries.ToList();
            return list;
        }

        public List<Subsidary> GetUnmappedSubsidiariesByEmpID(int? empId)
        {
            List<Subsidary> sub = dbconn.GetUnmappedSubsidiariesByEmpID(empId).ToList();
            return sub;
        }

    }
}

