using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSPDevTools.Model;

namespace TSPDevTool.UI.Models
{
    public class EmpResultModel
    {
        public double MatchedSkillsPercentage;
        public Employee Employee;

        public EmpResultModel(double matchedSkillsPercentage, Employee employee)
        {
            this.MatchedSkillsPercentage = matchedSkillsPercentage;
            this.Employee = employee;
        }
    }
}