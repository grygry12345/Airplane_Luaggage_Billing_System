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
    
    public partial class Security
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Security()
        {
            this.Luggage = new HashSet<Luggage>();
            this.Passanger = new HashSet<Passanger>();
        }
    
        public int SecurityId { get; set; }
        public int airEmId { get; set; }
    
        public virtual Airport_Employee Airport_Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luggage> Luggage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passanger> Passanger { get; set; }
    }
}
