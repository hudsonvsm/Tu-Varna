//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy.WebApp.DbDiagram
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sell
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sell()
        {
            this.SoldMedicine = new HashSet<SoldMedicine>();
        }
    
        public System.Guid Id { get; set; }
        public int Number { get; set; }
        public System.DateTime DoneAt { get; set; }
        public System.Guid CounterpartyId { get; set; }
    
        public virtual Counterparty Counterparty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoldMedicine> SoldMedicine { get; set; }
    }
}
