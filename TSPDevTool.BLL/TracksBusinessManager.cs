using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class TracksBusinessManager
    {
        TracksDataManager tracksDataManager;

        public TracksBusinessManager(TSPEntities dbconn)
        {
            tracksDataManager = new TracksDataManager(dbconn);
        }

        public Track GetById(int id)
        {
            return tracksDataManager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            tracksDataManager.DeleteById(id);
        }
        public Track Add(Track tr)
        {
            return tracksDataManager.Add(tr);
        }
        public Track Update(Track tr)
        {
            return tracksDataManager.Update(tr);
        }
        public List<Track> GetAll()
        {
            return tracksDataManager.GetAll();
        }

    }
}
