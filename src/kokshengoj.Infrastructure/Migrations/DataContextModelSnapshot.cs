﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kokshengoj.Infrastructure.Persistence;

#nullable disable

namespace kokshengoj.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("kokshengoj.Domain.QuestionAggregate.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("acceptedNum")
                        .HasColumnType("int");

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("favourNum")
                        .HasColumnType("int");

                    b.Property<int>("isDelete")
                        .HasColumnType("int");

                    b.Property<string>("judgeCase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("judgeConfig")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("submitNum")
                        .HasColumnType("int");

                    b.Property<string>("tags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("thumbNum")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("kokshengoj.Domain.QuestionSubmitAggregate.QuestionSubmit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("isDelete")
                        .HasColumnType("int");

                    b.Property<string>("judgeInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("questionId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuestionSubmits", (string)null);
                });

            modelBuilder.Entity("kokshengoj.Domain.UserAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("gender")
                        .HasColumnType("int");

                    b.Property<bool?>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("userAccount")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("userAvatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
