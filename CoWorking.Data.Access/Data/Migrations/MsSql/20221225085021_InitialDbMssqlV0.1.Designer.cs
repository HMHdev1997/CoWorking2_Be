﻿// <auto-generated />
using System;
using CoWorking.Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoWorking.Data.Access.Data.Migrations.MsSql
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20221225085021_InitialDbMssqlV0.1")]
    partial class InitialDbMssqlV01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoWorking.Data.Model.Area", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ID");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OfficeId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CoWorking.Data.Model.BookingDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreaetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("BookingId");

                    b.ToTable("BookingDetail");
                });

            modelBuilder.Entity("CoWorking.Data.Model.CategoryOffice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Decription")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ID");

                    b.ToTable("CategoryOffice");
                });

            modelBuilder.Entity("CoWorking.Data.Model.CategoryService", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Decription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ID");

                    b.ToTable("CategoryService");
                });

            modelBuilder.Entity("CoWorking.Data.Model.CategorySpace", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookingID")
                        .HasColumnType("int");

                    b.Property<string>("Decription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("BookingID");

                    b.ToTable("CategorySpace");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Gender")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("IdentifierCode")
                        .HasColumnType("int");

                    b.Property<string>("ImagePart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Point")
                        .HasColumnType("float");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CoWorking.Data.Model.FeedBack", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OfficeId");

                    b.HasIndex("UserId");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Manager", b =>
                {
                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("OfficeId", "StaffId");

                    b.HasIndex("StaffId");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Office", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("GenenalDecription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("HotFlag")
                        .HasColumnType("bit");

                    b.Property<long>("Latitude")
                        .HasColumnType("bigint");

                    b.Property<long>("Longitude")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOffice")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AreaId");

                    b.ToTable("Office");
                });

            modelBuilder.Entity("CoWorking.Data.Model.OfficeImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("PartImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OfficeId");

                    b.ToTable("OfficeImage");
                });

            modelBuilder.Entity("CoWorking.Data.Model.OfficeInCategory", b =>
                {
                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryOfficeId")
                        .HasColumnType("int");

                    b.HasKey("OfficeId", "CategoryOfficeId");

                    b.HasIndex("CategoryOfficeId");

                    b.ToTable("OfficeInCategory");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BaseSalary")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Decription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryServiceId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Space", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategorySpaceId")
                        .HasColumnType("int");

                    b.Property<int>("LocationSpace")
                        .HasColumnType("int");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Staus")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorySpaceId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Space");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Fullname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("IdentifierCode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PhoneNumbers")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoleId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("CoWorking.Data.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumbers")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Booking", b =>
                {
                    b.HasOne("CoWorking.Data.Model.Office", "Office")
                        .WithMany("Bookings")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoWorking.Data.Model.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoWorking.Data.Model.BookingDetail", b =>
                {
                    b.HasOne("CoWorking.Data.Model.Booking", "Booking")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("CoWorking.Data.Model.CategorySpace", b =>
                {
                    b.HasOne("CoWorking.Data.Model.Booking", null)
                        .WithMany("Spaces")
                        .HasForeignKey("BookingID");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Customer", b =>
                {
                    b.HasOne("CoWorking.Data.Model.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("CoWorking.Data.Model.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoWorking.Data.Model.FeedBack", b =>
                {
                    b.HasOne("CoWorking.Data.Model.Office", "Office")
                        .WithMany("FeedBacks")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoWorking.Data.Model.User", "User")
                        .WithMany("FeedBacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Manager", b =>
                {
                    b.HasOne("CoWorking.Data.Model.Office", "Office")
                        .WithMany("Managers")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoWorking.Data.Model.Staff", "Staff")
                        .WithMany("Managers")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Office", b =>
                {
                    b.HasOne("CoWorking.Data.Model.Area", "Area")
                        .WithMany("Offices")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("CoWorking.Data.Model.OfficeImage", b =>
                {
                    b.HasOne("CoWorking.Data.Model.Office", "Office")
                        .WithMany("OfficeImages")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("CoWorking.Data.Model.OfficeInCategory", b =>
                {
                    b.HasOne("CoWorking.Data.Model.CategoryOffice", "CategoryOffice")
                        .WithMany("OfficeInCategories")
                        .HasForeignKey("CategoryOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoWorking.Data.Model.Office", "Office")
                        .WithMany("OfficeInCategories")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryOffice");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Service", b =>
                {
                    b.HasOne("CoWorking.Data.Model.CategoryService", "CategoryService")
                        .WithMany("Services")
                        .HasForeignKey("CategoryServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoWorking.Data.Model.Office", "Office")
                        .WithMany("Services")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryService");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Space", b =>
                {
                    b.HasOne("CoWorking.Data.Model.CategorySpace", "CategorySpace")
                        .WithMany("Spaces")
                        .HasForeignKey("CategorySpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoWorking.Data.Model.Office", "Office")
                        .WithMany("Spaces")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategorySpace");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Staff", b =>
                {
                    b.HasOne("CoWorking.Data.Model.Role", "Role")
                        .WithMany("Staffs")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Area", b =>
                {
                    b.Navigation("Offices");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Booking", b =>
                {
                    b.Navigation("BookingDetails");

                    b.Navigation("Spaces");
                });

            modelBuilder.Entity("CoWorking.Data.Model.CategoryOffice", b =>
                {
                    b.Navigation("OfficeInCategories");
                });

            modelBuilder.Entity("CoWorking.Data.Model.CategoryService", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("CoWorking.Data.Model.CategorySpace", b =>
                {
                    b.Navigation("Spaces");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Office", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("FeedBacks");

                    b.Navigation("Managers");

                    b.Navigation("OfficeImages");

                    b.Navigation("OfficeInCategories");

                    b.Navigation("Services");

                    b.Navigation("Spaces");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Role", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("CoWorking.Data.Model.Staff", b =>
                {
                    b.Navigation("Managers");
                });

            modelBuilder.Entity("CoWorking.Data.Model.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Customer");

                    b.Navigation("FeedBacks");
                });
#pragma warning restore 612, 618
        }
    }
}
