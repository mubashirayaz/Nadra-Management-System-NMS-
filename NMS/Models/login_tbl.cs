//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class login_tbl
    {
        public int login_id { get; set; }
        public string login_email { get; set; }
        public string login_password { get; set; }
        public Nullable<int> staff_id { get; set; }
    
        public virtual staff_tbl staff_tbl { get; set; }
    }
}