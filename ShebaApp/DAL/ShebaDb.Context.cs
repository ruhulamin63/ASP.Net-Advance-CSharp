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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShebaDbEntities : DbContext
    {
        public ShebaDbEntities()
            : base("name=ShebaDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Bonu> Bonus { get; set; }
        public DbSet<Booking_Details> Booking_Details { get; set; }
        public DbSet<Booking_Service> Booking_Service { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer_Coupon> Customer_Coupon { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Login_Time> Login_Time { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<ServiceProvider_Bonus> ServiceProvider_Bonus { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
