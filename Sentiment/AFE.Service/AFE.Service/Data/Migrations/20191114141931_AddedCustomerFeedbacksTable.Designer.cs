﻿// <auto-generated />
using System;
using AFE.Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AFE.Service.Data.Migrations
{
    [DbContext(typeof(AFEContext))]
    [Migration("20191114141931_AddedCustomerFeedbacksTable")]
    partial class AddedCustomerFeedbacksTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AFE.Service.Data.Entities.CustomerFeedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Probability");

                    b.Property<decimal>("Score");

                    b.Property<bool>("SentToML");

                    b.Property<bool>("Sentiment");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("CustomerFeedbacks");
                });

            modelBuilder.Entity("AFE.Service.Data.Entities.MLInputFeedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("Sentiment");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("MLInputFeedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
