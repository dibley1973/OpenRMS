using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenRMS.Contexts.ItemManagement.Infrastructure.PostgreSql;

namespace OpenRMS.Contexts.ItemManagement.Infrastructure.PostgreSql.Migrations
{
    [DbContext(typeof(PostgreSqlItemManagementContext))]
    [Migration("20161026195626_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:.uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("OpenRMS.Contexts.ItemManagement.Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ItemCodeValue");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });
        }
    }
}
