//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TSPDevTools.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmpSubsidary
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public int SubsidaryID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Subsidary Subsidary { get; set; }
    }
}
