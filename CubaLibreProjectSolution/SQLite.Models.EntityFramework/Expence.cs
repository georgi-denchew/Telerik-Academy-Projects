//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQLite.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Expence
    {
        public long ExpenceID { get; set; }
        public string VendorName { get; set; }
        public decimal CurrentExpence { get; set; }
        public System.DateTime CurrentMoth { get; set; }
    }
}