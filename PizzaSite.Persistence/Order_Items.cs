//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzaSite.Persistence
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Items
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
