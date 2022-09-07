﻿// <auto-generated />
using System;
using InfinityMesh.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfinityMesh.Migrations
{
    [DbContext(typeof(ElectionContext))]
    [Migration("20220906162858_DataAnt")]
    partial class DataAnt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InfinityMesh.Models.Candidate", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidateId"), 1L, 1);

                    b.Property<int>("AllVotes")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CandidateId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("InfinityMesh.Models.Constituency", b =>
                {
                    b.Property<int>("ConstituencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConstituencyId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConstituencyId");

                    b.ToTable("Constituencies");
                });

            modelBuilder.Entity("InfinityMesh.Models.Votes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CandidateCode")
                        .HasColumnType("int");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("ConstituencyId")
                        .HasColumnType("int");

                    b.Property<int?>("ConstituencyName")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfVotes")
                        .HasColumnType("int");

                    b.Property<bool?>("OverrideFile")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("ConstituencyId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("InfinityMesh.Models.Votes", b =>
                {
                    b.HasOne("InfinityMesh.Models.Candidate", "Candidate")
                        .WithMany("Votes")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfinityMesh.Models.Constituency", "Constituency")
                        .WithMany("Votes")
                        .HasForeignKey("ConstituencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Constituency");
                });

            modelBuilder.Entity("InfinityMesh.Models.Candidate", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("InfinityMesh.Models.Constituency", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}