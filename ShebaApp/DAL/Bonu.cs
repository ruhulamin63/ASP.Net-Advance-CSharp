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
    
    public partial class Bonu
    {
        public Bonu()
        {
            this.ServiceProvider_Bonus = new HashSet<ServiceProvider_Bonus>();
        }
    
        public int id { get; set; }
        public int min_service_done { get; set; }
        public int bonus_amount { get; set; }
    
        public virtual ICollection<ServiceProvider_Bonus> ServiceProvider_Bonus { get; set; }
    }
}
