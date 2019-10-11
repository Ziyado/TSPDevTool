﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TSPEntities : DbContext
    {
        public TSPEntities()
            : base("name=TSPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmpSkill> EmpSkills { get; set; }
        public virtual DbSet<EmpSubsidary> EmpSubsidaries { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Subsidary> Subsidaries { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TrackSkill> TrackSkills { get; set; }
        public virtual DbSet<Workload> Workloads { get; set; }
        public virtual DbSet<SkillLevel> SkillLevels { get; set; }
        public virtual DbSet<System_Users> System_Users { get; set; }
    
        public virtual ObjectResult<Skill> GetUnmappedSkillsByEmpId(Nullable<int> empid)
        {
            var empidParameter = empid.HasValue ?
                new ObjectParameter("empid", empid) :
                new ObjectParameter("empid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Skill>("GetUnmappedSkillsByEmpId", empidParameter);
        }
    
        public virtual ObjectResult<Skill> GetUnmappedSkillsByEmpId(Nullable<int> empid, MergeOption mergeOption)
        {
            var empidParameter = empid.HasValue ?
                new ObjectParameter("empid", empid) :
                new ObjectParameter("empid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Skill>("GetUnmappedSkillsByEmpId", mergeOption, empidParameter);
        }
    
        public virtual ObjectResult<Subsidary> GetUnmappedSubsidiariesByEmpID(Nullable<int> empid)
        {
            var empidParameter = empid.HasValue ?
                new ObjectParameter("empid", empid) :
                new ObjectParameter("empid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Subsidary>("GetUnmappedSubsidiariesByEmpID", empidParameter);
        }
    
        public virtual ObjectResult<Subsidary> GetUnmappedSubsidiariesByEmpID(Nullable<int> empid, MergeOption mergeOption)
        {
            var empidParameter = empid.HasValue ?
                new ObjectParameter("empid", empid) :
                new ObjectParameter("empid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Subsidary>("GetUnmappedSubsidiariesByEmpID", mergeOption, empidParameter);
        }
    
        public virtual ObjectResult<Skill> GetUnmappedSkillsByTrackId(Nullable<int> trackid)
        {
            var trackidParameter = trackid.HasValue ?
                new ObjectParameter("trackid", trackid) :
                new ObjectParameter("trackid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Skill>("GetUnmappedSkillsByTrackId", trackidParameter);
        }
    
        public virtual ObjectResult<Skill> GetUnmappedSkillsByTrackId(Nullable<int> trackid, MergeOption mergeOption)
        {
            var trackidParameter = trackid.HasValue ?
                new ObjectParameter("trackid", trackid) :
                new ObjectParameter("trackid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Skill>("GetUnmappedSkillsByTrackId", mergeOption, trackidParameter);
        }
    }
}