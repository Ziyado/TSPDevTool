//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TSPDevTool.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Skill_Level
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skill_Level()
        {
            this.EmpSkills = new HashSet<EmpSkill>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpSkill> EmpSkills { get; set; }
    }
}
