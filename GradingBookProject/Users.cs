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
    
    public partial class Users
    {
        public Users()
        {
            this.Years = new HashSet<Years>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string passwd { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    
        public virtual ICollection<Years> Years { get; set; }
    }
}
