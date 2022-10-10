﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using USFH.Database;

#nullable disable

namespace USFH.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("USFH.Areas.Admin.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("USFH.Models.AboutUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext")
                        .HasColumnName("imagepath");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.ToTable("aboutus", (string)null);
                });

            modelBuilder.Entity("USFH.Models.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext")
                        .HasColumnName("imagepath");

                    b.Property<string>("MainTitle")
                        .HasColumnType("longtext")
                        .HasColumnName("maintitle");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasColumnName("order");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.Property<string>("SubTitle")
                        .HasColumnType("longtext")
                        .HasColumnName("subtitle");

                    b.Property<string>("TopTitle")
                        .HasColumnType("longtext")
                        .HasColumnName("toptitle");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.ToTable("banners", (string)null);
                });

            modelBuilder.Entity("USFH.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("imagepath");

                    b.Property<string>("Slug")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("slug");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("subtitle");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("blogs", (string)null);
                });

            modelBuilder.Entity("USFH.Models.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("MainEmail")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("mainemail");

                    b.Property<string>("MainPhone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("mainphone");

                    b.Property<string>("MapX")
                        .HasColumnType("longtext")
                        .HasColumnName("mapx");

                    b.Property<string>("MapY")
                        .HasColumnType("longtext")
                        .HasColumnName("mapy");

                    b.Property<string>("SecondEmail")
                        .HasColumnType("longtext")
                        .HasColumnName("secondemail");

                    b.Property<string>("SecondPhone")
                        .HasColumnType("longtext")
                        .HasColumnName("secondphone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.ToTable("contactus", (string)null);
                });

            modelBuilder.Entity("USFH.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("messagetext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("subject");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.ToTable("messages", (string)null);
                });

            modelBuilder.Entity("USFH.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnType("longtext")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("USFH.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("orderid");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int")
                        .HasColumnName("productcount");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("productid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("orderproduct", (string)null);
                });

            modelBuilder.Entity("USFH.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("categoryid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<bool>("Discount")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("discount");

                    b.Property<double>("DiscountRate")
                        .HasColumnType("double")
                        .HasColumnName("discountrate");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("imagelink");

                    b.Property<string>("ItemNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("itemnumber");

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<string>("ProductFeatures")
                        .HasColumnType("longtext");

                    b.Property<int?>("SellingCount")
                        .HasColumnType("int")
                        .HasColumnName("sellingcount");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("slug");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.Property<string>("StockLevel")
                        .HasColumnType("longtext")
                        .HasColumnName("stocklevel");

                    b.Property<bool>("StockStatus")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("stockstatus");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.Property<double?>("Weight")
                        .IsRequired()
                        .HasColumnType("double")
                        .HasColumnName("weight");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("USFH.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext")
                        .HasColumnName("imagepath");

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("parentid");

                    b.Property<string>("Slug")
                        .HasColumnType("longtext")
                        .HasColumnName("slug");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.ToTable("productcategories", (string)null);
                });

            modelBuilder.Entity("USFH.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("ImageLink")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("productid");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("productimages", (string)null);
                });

            modelBuilder.Entity("USFH.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Key")
                        .HasColumnType("longtext")
                        .HasColumnName("key");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.Property<string>("Value")
                        .HasColumnType("longtext")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("settings", (string)null);
                });

            modelBuilder.Entity("USFH.Models.Slide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("ButtonTitle")
                        .HasColumnType("longtext")
                        .HasColumnName("buttontitle");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createddate");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image");

                    b.Property<string>("MainTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("maintitle");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasColumnName("order");

                    b.Property<string>("Slug")
                        .HasColumnType("longtext")
                        .HasColumnName("slug");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("subtitle");

                    b.Property<string>("TopTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("toptitle");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updateddate");

                    b.HasKey("Id");

                    b.ToTable("slides", (string)null);
                });

            modelBuilder.Entity("USFH.Models.OrderProduct", b =>
                {
                    b.HasOne("USFH.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USFH.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("USFH.Models.Product", b =>
                {
                    b.HasOne("USFH.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("USFH.Models.ProductImage", b =>
                {
                    b.HasOne("USFH.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("USFH.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("USFH.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("USFH.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
