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
    public class TracksDataManager
    {
        TSPEntities dbconn;

        public TracksDataManager(TSPEntities dbconn)
        {
            this.dbconn = dbconn;
        }

        public Track GetById(int id)
        {
            Track emp = dbconn.Tracks.Where(e => e.ID == id).Include("TrackSkills").FirstOrDefault();
            return emp;
        }
        public void DeleteById(int id)
        {

            Track emp = GetById(id);
            dbconn.Tracks.Remove(emp);
            dbconn.SaveChanges();
        }

        public Track Add(Track emp)
        {
            Track addedEmp = dbconn.Tracks.Add(emp);
            dbconn.SaveChanges();

            return addedEmp;
        }
        public Track Update(Track emp)
        {

            dbconn.Entry(emp).State = EntityState.Modified;
            dbconn.SaveChanges();
            return emp;
        }
        public List<Track> GetAll()
        {
            List<Track> tr = dbconn.Tracks.ToList();
            return tr;
        }

    }
}

