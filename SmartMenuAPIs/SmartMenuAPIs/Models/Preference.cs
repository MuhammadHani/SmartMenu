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
    
    public partial class Preference
    {
        public int ID { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> State { get; set; }
    }
}
