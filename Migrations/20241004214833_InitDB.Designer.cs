﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi.Models;

#nullable disable

namespace TodoApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241004214833_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("TodoApi.Models.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("BeerId");

                    b.HasIndex("BrandID");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("TodoApi.Models.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("TodoApi.Models.TodoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("secret")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("TodoApi.Models.Beer", b =>
                {
                    b.HasOne("TodoApi.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });
#pragma warning restore 612, 618
        }
    }
}
