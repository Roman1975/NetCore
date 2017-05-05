using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LayeredApp.Domain;

namespace LayeredApp.Domain.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20170321145211_IntialMigration")]
    partial class IntialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("LayeredApp.Domain.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateFinish");

                    b.Property<DateTime?>("DateStart");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Todos");
                });
        }
    }
}
