//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace home_service.Models.EntityFramwork
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service_provider_status
    {
        public int id { get; set; }
        public int service_provider_id { get; set; }
        public string status { get; set; }
    
        public virtual LoginUser LoginUser { get; set; }
    }
}
