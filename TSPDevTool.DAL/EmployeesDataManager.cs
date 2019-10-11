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
    public class EmployeesDataManager           // The Class
    {
        TSPEntities dbconn;

        public EmployeesDataManager(TSPEntities dbconn)       // Constructor for db connection 
        {
            this.dbconn = dbconn;
        }

        public Employee GetById(int id)          // Get the ID Function 
        {
            Employee emp = dbconn.Employees.Where(e => e.ID == id).Include("EmpSkills").Include("EmpSubsidaries").FirstOrDefault(); // include to fix save button 
       
            return emp;
        }
        public void DeleteById(int id)           // Delete function 
        {
            
            Employee emp = GetById(id);
            dbconn.Employees.Remove(emp);
            dbconn.SaveChanges();
        }

       public Employee Add(Employee emp)      // Adding Function 
        {
            Employee addedEmp = dbconn.Employees.Add(emp);
            dbconn.SaveChanges();

            return addedEmp;
        }
       public Employee Update(Employee emp)    // Update Function 
        {

            dbconn.Entry(emp).State = EntityState.Modified;
            dbconn.SaveChanges();
            return emp;
        }
        public List<Employee> GetAll()
        {

           
          List<Employee> emp = dbconn.Employees.ToList();
            return emp;
        }



    }
    }

