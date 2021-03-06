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
    
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            this.Ticket = new HashSet<Ticket>();
        }
    
        public int flightId { get; set; }
        public System.DateTime date { get; set; }
        public System.TimeSpan boardingTime { get; set; }
        public System.TimeSpan departureTime { get; set; }
        public System.TimeSpan arrivalTime { get; set; }
        public string startPointName { get; set; }
        public string destinationName { get; set; }
    
        public virtual Airports Airports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
