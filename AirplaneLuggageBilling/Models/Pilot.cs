//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirplaneLuggageBilling.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pilot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pilot()
        {
            this.Airplane = new HashSet<Airplane>();
        }
    
        public int pilotId { get; set; }
        public Nullable<int> coEmId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Airplane> Airplane { get; set; }
        public virtual Company_Employee Company_Employee { get; set; }
    }
}
