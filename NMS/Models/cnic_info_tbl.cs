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
    
    public partial class cnic_info_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnic_info_tbl()
        {
            this.citizen_tbl = new HashSet<citizen_tbl>();
            this.payment_tbl = new HashSet<payment_tbl>();
            this.staff_tbl = new HashSet<staff_tbl>();
        }
    
        public int cnic_id { get; set; }
        public string cnic_no { get; set; }
        public string issue_day { get; set; }
        public string issue_year { get; set; }
        public string issue_month { get; set; }
        public string expiry_year { get; set; }
        public string expiry_month { get; set; }
        public string expiry_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<citizen_tbl> citizen_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment_tbl> payment_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff_tbl> staff_tbl { get; set; }
    }
}
