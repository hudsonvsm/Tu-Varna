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
    
    public partial class QuestionVariant
    {
        public System.Guid NumberId { get; set; }
        public int Variant { get; set; }
        public System.Guid QuestionId { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual QuestionNumber QuestionNumber { get; set; }
    }
}