using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSPDevTools.Model;

namespace TSPDevTool.UI.Models
{
    public class SkillModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static SkillModel Translate(Skill skill)
        {
            var skillModel = new SkillModel();
            skillModel.Name = skill.Name;
            skillModel.ID = skill.ID;
            return skillModel;
        }

        public static List<SkillModel> Translate(List<Skill> skills)
        {
            var skillModelList = new List<SkillModel>();
            foreach (var item in skills)
            {
                var translatedItem = Translate(item);
                skillModelList.Add(translatedItem);
            }
            return skillModelList;
        }
    }
}