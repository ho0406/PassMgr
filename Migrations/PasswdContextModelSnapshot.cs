﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PassMgr.Models;
using System;

namespace PassMgr.Migrations
{
    [DbContext(typeof(PasswdContext))]
    partial class PasswdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("PassMgr.Models.Password", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Domain");

                    b.Property<string>("Ip");

                    b.Property<string>("Passwd");

                    b.Property<string>("Service");

                    b.Property<string>("Status");

                    b.Property<string>("Url");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("Passwords");
                });
#pragma warning restore 612, 618
        }
    }
}
