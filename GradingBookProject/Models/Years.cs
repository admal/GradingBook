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
    
    public partial class Years : DataEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Years()
        {
            this.Subjects = new HashSet<Subjects>();
        }
    
       // public int id { get; set; }
        public string name { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end_date { get; set; }
        public string year_desc { get; set; }
        public int user_id { get; set; }
        public Nullable<int> group_id { get; set; }
    
        public virtual Groups Groups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subjects> Subjects { get; set; }
        public virtual Users Users { get; set; }
    }
}
