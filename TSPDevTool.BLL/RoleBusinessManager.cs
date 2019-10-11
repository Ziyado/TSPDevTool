using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class RoleBusinessManager
    {
        RoleDataManager roleDataManager;

        public RoleBusinessManager(TSPEntities dbconn)   
        {
            roleDataManager = new RoleDataManager(dbconn);
        }

        public Role GetById(int id)
        {
            return roleDataManager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            roleDataManager.DeleteById(id);
        }
        public Role Add(Role rol)
        {
            return roleDataManager.Add(rol);
        }
        public Role Update(Role rol)
        {
            return roleDataManager.Update(rol);
        }
        public List<Role> GetAll()
        {
            return roleDataManager.GetAll();
        }

    }
}
