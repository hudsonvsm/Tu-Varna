//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Car.Rental.Web.App.DbDiagram.UNI
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionNumber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionNumber()
        {
            this.QuestionVariant = new HashSet<QuestionVariant>();
        }
    
        public System.Guid Id { get; set; }
        public int Number { get; set; }
        public System.Guid TestId { get; set; }
    
        public virtual Test Test { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionVariant> QuestionVariant { get; set; }
    }
}
