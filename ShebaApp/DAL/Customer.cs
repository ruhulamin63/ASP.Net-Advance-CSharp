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
    
    public partial class Customer
    {
        public Customer()
        {
            this.Bookings = new HashSet<Booking>();
            this.Customer_Coupon = new HashSet<Customer_Coupon>();
            this.Reviews = new HashSet<Review>();
        }
    
        public int id { get; set; }
        public int user_id { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Customer_Coupon> Customer_Coupon { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual User User { get; set; }
    }
}