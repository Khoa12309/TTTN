﻿// <auto-generated />
using System;
using DataTTTN.ContextdataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataTTTN.Migrations
{
    [DbContext(typeof(TTTNContext))]
    [Migration("20230921040122_lan6")]
    partial class lan6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataTTTN.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id_User")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_User")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DataTTTN.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("DataTTTN.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_account")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id_account");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DataTTTN.Models.Cart_details", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Cart")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_productdetails")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid?>("Product_DetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Id_Cart");

                    b.HasIndex("Product_DetailsId");

                    b.ToTable("Cart_Details");
                });

            modelBuilder.Entity("DataTTTN.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataTTTN.Models.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("DataTTTN.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Product_details")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Product_DetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Product_DetailsId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DataTTTN.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("DataTTTN.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_account")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Noti_conten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_account");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("DataTTTN.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataTTTN.Models.Product_details", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("Id_Brand")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Category")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Color")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Material")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Product")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Size")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Sole")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Brand");

                    b.HasIndex("Id_Category");

                    b.HasIndex("Id_Color");

                    b.HasIndex("Id_Material");

                    b.HasIndex("Id_Product");

                    b.HasIndex("Id_Size");

                    b.HasIndex("Id_Sole");

                    b.ToTable("Products_details");
                });

            modelBuilder.Entity("DataTTTN.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("DataTTTN.Models.Sole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Last_modified_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Soles");
                });

            modelBuilder.Entity("DataTTTN.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Point")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataTTTN.Models.Account", b =>
                {
                    b.HasOne("DataTTTN.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("DataTTTN.Models.Account", "Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataTTTN.Models.Cart", b =>
                {
                    b.HasOne("DataTTTN.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("Id_account")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DataTTTN.Models.Cart_details", b =>
                {
                    b.HasOne("DataTTTN.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("Id_Cart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataTTTN.Models.Product_details", "Product_Details")
                        .WithMany()
                        .HasForeignKey("Product_DetailsId");

                    b.Navigation("Cart");

                    b.Navigation("Product_Details");
                });

            modelBuilder.Entity("DataTTTN.Models.Image", b =>
                {
                    b.HasOne("DataTTTN.Models.Product_details", "Product_Details")
                        .WithMany()
                        .HasForeignKey("Product_DetailsId");

                    b.Navigation("Product_Details");
                });

            modelBuilder.Entity("DataTTTN.Models.Notification", b =>
                {
                    b.HasOne("DataTTTN.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("Id_account")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DataTTTN.Models.Product_details", b =>
                {
                    b.HasOne("DataTTTN.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("Id_Brand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataTTTN.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Id_Category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataTTTN.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("Id_Color")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataTTTN.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("Id_Material")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataTTTN.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Id_Product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataTTTN.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("Id_Size")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataTTTN.Models.Sole", "Sole")
                        .WithMany()
                        .HasForeignKey("Id_Sole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("Material");

                    b.Navigation("Product");

                    b.Navigation("Size");

                    b.Navigation("Sole");
                });

            modelBuilder.Entity("DataTTTN.Models.User", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
