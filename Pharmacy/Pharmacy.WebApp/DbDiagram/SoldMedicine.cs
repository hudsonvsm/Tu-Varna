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
    
    public partial class SoldMedicine
    {
        public System.Guid Id { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public System.Guid MedicineId { get; set; }
        public System.Guid SellId { get; set; }
    
        public virtual Medicine Medicine { get; set; }
        public virtual Sell Sell { get; set; }
    }
}
