//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartMenuAPIs.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderItem
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public Nullable<int> SideDish1 { get; set; }
        public Nullable<int> SideDish2 { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
