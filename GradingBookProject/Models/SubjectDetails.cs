//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GradingBookProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubjectDetails : DataEntity
    {
        //public int id { get; set; }
        public int sub_id { get; set; }
        public string grade_desc { get; set; }
        public int grade_weight { get; set; }
        public Nullable<System.DateTime> grade_date { get; set; }
        public double grade_value { get; set; }
    
        public virtual Subjects Subjects { get; set; }
    }
}
