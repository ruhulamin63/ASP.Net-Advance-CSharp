//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ghor_Sheba.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public Booking()
        {
            this.Booking_confirms = new HashSet<Booking_confirms>();
            this.Booking_details = new HashSet<Booking_details>();
        }
    
        public int id { get; set; }
        public int customer_id { get; set; }
        public int cost { get; set; }
        public string status { get; set; }
        public string payment_status { get; set; }
    
        public virtual ICollection<Booking_confirms> Booking_confirms { get; set; }
        public virtual ICollection<Booking_details> Booking_details { get; set; }
        public virtual LoginUser LoginUser { get; set; }
    }
}
