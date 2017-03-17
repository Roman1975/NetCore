using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using coreapiwithpostgresql.Domain;

namespace coreapiwithpostgresql.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    [Migration("20170317140705_ChangeRequiredFields")]
    partial class ChangeRequiredFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("coreapiwithpostgresql.Model.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateFinish");

                    b.Property<DateTime?>("DateStart");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Todos");
                });
        }
    }
}
