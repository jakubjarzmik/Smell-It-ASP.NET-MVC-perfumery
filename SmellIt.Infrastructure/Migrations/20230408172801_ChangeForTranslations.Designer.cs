﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmellIt.Infrastructure.Persistence;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    [DbContext(typeof(SmellItDbContext))]
    [Migration("20230408172801_ChangeForTranslations")]
    partial class ChangeForTranslations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SmellIt.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionKey")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.FragranceGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionKey")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("FragranceGroups");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionKey")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionKey")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FragranceGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("FragranceGroupId");

                    b.HasIndex("GenderId");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionKey")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("ImageAlt")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Address", b =>
                {
                    b.HasOne("SmellIt.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedAddresses")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "DeletedBy")
                        .WithMany("DeletedAddresses")
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "ModifiedBy")
                        .WithMany("ModifiedAddresses")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Brand", b =>
                {
                    b.HasOne("SmellIt.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedBrands")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "DeletedBy")
                        .WithMany("DeletedBrands")
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "ModifiedBy")
                        .WithMany("ModifiedBrands")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.FragranceGroup", b =>
                {
                    b.HasOne("SmellIt.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedFragranceGroups")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "DeletedBy")
                        .WithMany("DeletedFragranceGroups")
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "ModifiedBy")
                        .WithMany("ModifiedFragranceGroups")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Gender", b =>
                {
                    b.HasOne("SmellIt.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedGenders")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "DeletedBy")
                        .WithMany("DeletedGenders")
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "ModifiedBy")
                        .WithMany("ModifiedGenders")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Product", b =>
                {
                    b.HasOne("SmellIt.Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmellIt.Domain.Entities.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmellIt.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedProducts")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "DeletedBy")
                        .WithMany("DeletedProducts")
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.FragranceGroup", "FragranceGroup")
                        .WithMany("Products")
                        .HasForeignKey("FragranceGroupId");

                    b.HasOne("SmellIt.Domain.Entities.Gender", "Gender")
                        .WithMany("Products")
                        .HasForeignKey("GenderId");

                    b.HasOne("SmellIt.Domain.Entities.User", "ModifiedBy")
                        .WithMany("ModifiedProducts")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("FragranceGroup");

                    b.Navigation("Gender");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("SmellIt.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedProductCategories")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "DeletedBy")
                        .WithMany("DeletedProductCategories")
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "ModifiedBy")
                        .WithMany("ModifiedProductCategories")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.ProductCategory", "ParentCategory")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("SmellIt.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedProductImages")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "DeletedBy")
                        .WithMany("DeletedProductImages")
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "ModifiedBy")
                        .WithMany("ModifiedProductImages")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Translation", b =>
                {
                    b.HasOne("SmellIt.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedTranslations")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "DeletedBy")
                        .WithMany("DeletedTranslations")
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "ModifiedBy")
                        .WithMany("ModifiedTranslations")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.User", b =>
                {
                    b.HasOne("SmellIt.Domain.Entities.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId");

                    b.HasOne("SmellIt.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedUsers")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "DeletedBy")
                        .WithMany("DeletedUsers")
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmellIt.Domain.Entities.User", "ModifiedBy")
                        .WithMany("ModifiedUsers")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Address");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Address", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.FragranceGroup", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Gender", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.ProductCategory", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("SmellIt.Domain.Entities.User", b =>
                {
                    b.Navigation("CreatedAddresses");

                    b.Navigation("CreatedBrands");

                    b.Navigation("CreatedFragranceGroups");

                    b.Navigation("CreatedGenders");

                    b.Navigation("CreatedProductCategories");

                    b.Navigation("CreatedProductImages");

                    b.Navigation("CreatedProducts");

                    b.Navigation("CreatedTranslations");

                    b.Navigation("CreatedUsers");

                    b.Navigation("DeletedAddresses");

                    b.Navigation("DeletedBrands");

                    b.Navigation("DeletedFragranceGroups");

                    b.Navigation("DeletedGenders");

                    b.Navigation("DeletedProductCategories");

                    b.Navigation("DeletedProductImages");

                    b.Navigation("DeletedProducts");

                    b.Navigation("DeletedTranslations");

                    b.Navigation("DeletedUsers");

                    b.Navigation("ModifiedAddresses");

                    b.Navigation("ModifiedBrands");

                    b.Navigation("ModifiedFragranceGroups");

                    b.Navigation("ModifiedGenders");

                    b.Navigation("ModifiedProductCategories");

                    b.Navigation("ModifiedProductImages");

                    b.Navigation("ModifiedProducts");

                    b.Navigation("ModifiedTranslations");

                    b.Navigation("ModifiedUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
