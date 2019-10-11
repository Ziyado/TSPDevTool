using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSPDevTools.Model;

namespace TSPDevTool.UI.Models
{
    public class TrackModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static TrackModel Translate(Track track)
        {
            var trackModel = new TrackModel();
            trackModel.Name = track.Name;
            trackModel.ID = track.ID;
            return trackModel;
        }

        public static List<TrackModel> Translate(List<Track> tracks)
        {
            var trackModelList = new List<TrackModel>();
            foreach (var item in tracks)
            {
                var translatedItem = Translate(item);
                trackModelList.Add(translatedItem);
            }
            return trackModelList;
        }

       
    }
}