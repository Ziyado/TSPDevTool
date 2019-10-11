using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTools.Model;

namespace TSPDevTool.DAL
{
    public class RoleDataManager
    {
        TSPEntities dbconn;

        public RoleDataManager(TSPEntities dbconn)
        {
            this.dbconn = dbconn;
        }

        public Role GetById(int id)
        {
            Role ro = dbconn.Roles.Where(e => e.ID == id).FirstOrDefault();
            return ro;
        }
        public void DeleteById(int id)
        {

            Role ro = GetById(id);
            dbconn.Roles.Remove(ro);
            dbconn.SaveChanges();

            
        }

        public Role Add(Role ro)
        {
            Role addedEmp = dbconn.Roles.Add(ro);
            dbconn.SaveChanges();

            return addedEmp;
        }
        public Role Update(Role ro)
        {
            dbconn.Entry(ro).State = EntityState.Modified;
            dbconn.SaveChanges();
            

            return ro;
        }
        public List<Role>GetAll()
        {


            List<Role> rol = dbconn.Roles.ToList();
            return rol;
        }
    }
}
