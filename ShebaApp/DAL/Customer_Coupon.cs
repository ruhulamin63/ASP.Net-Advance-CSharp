//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer_Coupon
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public int coupon_id { get; set; }
        public Nullable<int> used_count { get; set; }
    
        public virtual Coupon Coupon { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
