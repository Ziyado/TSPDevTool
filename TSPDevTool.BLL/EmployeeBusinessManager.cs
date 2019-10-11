using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class EmployeeBusinessManager
    {
        EmployeesDataManager employeesDataManager;

        public EmployeeBusinessManager(TSPEntities dbconn)
        {
            employeesDataManager = new EmployeesDataManager(dbconn);
        }
       
        public Employee GetById(int id) {
            return employeesDataManager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            employeesDataManager.DeleteById(id);
        }
        public Employee Add(Employee emp)
        {
            return employeesDataManager.Add(emp);
        }
        public Employee Update(Employee emp)
        {
            return employeesDataManager.Update(emp);
        }
        public List<Employee> GetAll()
        {
            return employeesDataManager.GetAll();
        }
      
    }
}
