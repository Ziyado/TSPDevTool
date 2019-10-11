using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPDevTool.DAL;
using TSPDevTools.Model;

namespace TSPDevTool.BLL
{
    public class TrackSkillsBusinessManager
    {
        TrackSkillsDataManager tracksskillsdatamanager;

        public TrackSkillsBusinessManager(TSPEntities dbconn)
        {
            tracksskillsdatamanager = new TrackSkillsDataManager(dbconn);
        }

        public TrackSkill GetById(int id)
        {
            return tracksskillsdatamanager.GetById(id);
        }
        public void Deletebyid(int id)
        {
            tracksskillsdatamanager.DeleteById(id);
        }
        public TrackSkill Add(TrackSkill emp)
        {
            return tracksskillsdatamanager.Add(emp);
        }
        public TrackSkill Update(TrackSkill emp)
        {
            return tracksskillsdatamanager.Update(emp);
        }
        public List<TrackSkill> GetAll()
        {
            return tracksskillsdatamanager.GetAll();
        }
        public List<TrackSkill> GetByTrackID(int id)
        {
            return tracksskillsdatamanager.GetByTrackID(id);
        }

        public void deleteSkillsByTrackID(int id)
        {

            tracksskillsdatamanager.deleteSkillsByTrackID(id);

        }


    }
}
