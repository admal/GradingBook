//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GradingBookProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubjectDetails
    {
        public int id { get; set; }
        public int sub_id { get; set; }
        public int grade_id { get; set; }
        public int grade_weight { get; set; }
        public DateTime grade_date { get; set; }
    
        public virtual Grades Grades { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}