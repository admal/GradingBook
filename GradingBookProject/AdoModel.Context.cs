﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GradingBookProject.Data;

namespace GradingBookProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GradingBookDbEntities : DbContext//, IGbUnitOfWork
    {
        public GradingBookDbEntities()
            : base("name=GradingBookDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public IDbSet<Grades> Grades { get; set; }
        public IDbSet<Subjects> Subjects { get; set; }
        public IDbSet<Users> Users { get; set; }
        public IDbSet<Years> Years { get; set; }
    }
}
