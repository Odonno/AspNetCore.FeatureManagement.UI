﻿// <auto-generated />
using System;
using AspNetCore.FeatureManagement.UI.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCore.FeatureManagement.UI.SqlServer.Storage.Migrations
{
    [DbContext(typeof(FeatureManagementDb))]
    [Migration("20200720200450_UseFeatureId")]
    partial class UseFeatureId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCore.FeatureManagement.UI.Core.Data.DecimalFeatureChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Choice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId", "Choice")
                        .IsUnique();

                    b.ToTable("DecimalFeatureChoice","FeatureManagement");
                });

            modelBuilder.Entity("AspNetCore.FeatureManagement.UI.Core.Data.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("BooleanValue")
                        .HasColumnType("bit");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int?>("IntValue")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("StringValue")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Feature","FeatureManagement");
                });

            modelBuilder.Entity("AspNetCore.FeatureManagement.UI.Core.Data.IntFeatureChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Choice")
                        .HasColumnType("int");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId", "Choice")
                        .IsUnique();

                    b.ToTable("IntFeatureChoice","FeatureManagement");
                });

            modelBuilder.Entity("AspNetCore.FeatureManagement.UI.Core.Data.StringFeatureChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Choice")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(450)");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId", "Choice")
                        .IsUnique();

                    b.ToTable("StringFeatureChoice","FeatureManagement");
                });

            modelBuilder.Entity("AspNetCore.FeatureManagement.UI.Core.Data.DecimalFeatureChoice", b =>
                {
                    b.HasOne("AspNetCore.FeatureManagement.UI.Core.Data.Feature", "Feature")
                        .WithMany("DecimalFeatureChoices")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCore.FeatureManagement.UI.Core.Data.IntFeatureChoice", b =>
                {
                    b.HasOne("AspNetCore.FeatureManagement.UI.Core.Data.Feature", "Feature")
                        .WithMany("IntFeatureChoices")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCore.FeatureManagement.UI.Core.Data.StringFeatureChoice", b =>
                {
                    b.HasOne("AspNetCore.FeatureManagement.UI.Core.Data.Feature", "Feature")
                        .WithMany("StringFeatureChoices")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
