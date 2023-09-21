using DataTTTN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataTTTN.ContextdataBase
{
    public class TTTNContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-N6FK027M;Initial Catalog=TTTN_2023;Persist Security Info=True;User ID=khoaph20877;Password=123456");



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Product_details> Products_details { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Sole> Soles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_details> Cart_Details { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Notification> Notifications { get; set; }  
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails>  OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Account_voucher>  Account_Vouchers{ get; set; }
        public DbSet<OrderHistory>  OrderHistories{ get; set; }
        public DbSet<PaymentMethod>  PaymentMethods{ get; set; }
        public DbSet<Voucher>   Vouchers{ get; set; }
        public DbSet<VoucherDetails> VoucherDetails { get; set; }






    }
}
