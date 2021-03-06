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
    
    public partial class Company_Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company_Employee()
        {
            this.Pilot = new HashSet<Pilot>();
            this.Teller = new HashSet<Teller>();
        }
    
        public int coEmId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public System.DateTime BDate { get; set; }
        public string Address { get; set; }
        public short Salary { get; set; }
        public string Sex { get; set; }
        public string AirCompanyName { get; set; }
        public string AirPortName { get; set; }
        public string employeeType { get; set; }
    
        public virtual Airports Airports { get; set; }
        public virtual Air_Company Air_Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pilot> Pilot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teller> Teller { get; set; }
    }
}
