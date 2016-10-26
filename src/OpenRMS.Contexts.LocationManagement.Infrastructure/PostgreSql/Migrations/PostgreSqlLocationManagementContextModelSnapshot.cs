using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenRMS.Contexts.LocationManagement.Infrastructure.PostgreSql;

namespace OpenRMS.Contexts.LocationManagement.Infrastructure.PostgreSql.Migrations
{
    [DbContext(typeof(PostgreSqlLocationManagementContext))]
    partial class PostgreSqlLocationManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:.uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("OpenRMS.Contexts.LocationManagement.Domain.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("LocationCodeValue");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });
        }
    }
}
