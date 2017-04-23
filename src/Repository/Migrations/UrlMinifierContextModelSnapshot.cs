﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UrlMinifier.Repository.Migrations
{
    [DbContext(typeof(UrlMinifierContext))]
    partial class UrlMinifierContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UrlMinifier.Domain.MinifiedUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClickCount");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateLastUpdated");

                    b.Property<string>("OriginalUrl")
                        .IsRequired();

                    b.Property<string>("ShortUrl");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MinifiedUrls");
                });

            modelBuilder.Entity("UrlMinifier.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UrlMinifier.Domain.MinifiedUrl", b =>
                {
                    b.HasOne("UrlMinifier.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
