using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSPDevTools.Model;

namespace TSPDevTool.UI.Models
{
    public class SubsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static SubsModel Translate(Subsidary sub)
        {
            var subModel = new SubsModel();
            subModel.Name = sub.Name;
            subModel.ID = sub.ID;
            return subModel;
        }

        public static List<SubsModel> Translate(List<Subsidary> subs)
        {
            var subModelList = new List<SubsModel>();
            foreach (var item in subs)
            {
                var translatedItem = Translate(item);
                subModelList.Add(translatedItem);
            }
            return subModelList;
        }
    }
}