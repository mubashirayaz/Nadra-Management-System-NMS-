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
    
    public partial class account_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account_tbl()
        {
            this.payment_tbl = new HashSet<payment_tbl>();
        }
    
        public int account_id { get; set; }
        public string accound_No { get; set; }
        public Nullable<int> invoice_id { get; set; }
    
        public virtual invoice_tbl invoice_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment_tbl> payment_tbl { get; set; }
    }
}
