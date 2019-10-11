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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.EmpSkills = new HashSet<EmpSkill>();
            this.EmpSubsidaries = new HashSet<EmpSubsidary>();
            this.Employees1 = new HashSet<Employee>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string Alias { get; set; }
        public Nullable<int> WorkloadID { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<int> ManagerID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpSkill> EmpSkills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpSubsidary> EmpSubsidaries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees1 { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual Role Role { get; set; }
        public virtual Workload Workload { get; set; }
    }
}
