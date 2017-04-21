using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UrlMinifier.Repository;

namespace UrlMinifier.Repository.Migrations
{
    [DbContext(typeof(UrlContext))]
    partial class UrlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UrlMinifier.Domain.Url", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClickCount");

                    b.Property<string>("CreatorIpAddress");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateLastUpdated");

                    b.Property<string>("OriginalUrl");

                    b.Property<string>("ShortUrl");

                    b.HasKey("Id");

                    b.ToTable("Urls");
                });
        }
    }
}
