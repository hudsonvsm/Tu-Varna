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
    
    public partial class SelectedAnswer
    {
        public System.Guid Id { get; set; }
        public System.Guid TestAttemptId { get; set; }
        public System.Guid AnswerId { get; set; }
    
        public virtual Answer Answer { get; set; }
        public virtual TestAttempt TestAttempt { get; set; }
    }
}