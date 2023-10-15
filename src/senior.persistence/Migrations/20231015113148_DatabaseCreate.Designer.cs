﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using senior.persistence.Context;

#nullable disable

namespace senior.persistence.Migrations
{
    [DbContext(typeof(SeniorDbContext))]
    [Migration("20231015113148_DatabaseCreate")]
    partial class DatabaseCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("senior.domain.Entites.Locality", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("locality", (string)null);
                });

            modelBuilder.Entity("senior.domain.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("PasswordHash");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("senior.domain.Entites.Locality", b =>
                {
                    b.OwnsOne("senior.domain.ValueObjects.CityName", "City", b1 =>
                        {
                            b1.Property<string>("LocalityId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("City");

                            b1.HasKey("LocalityId");

                            b1.HasIndex("Value")
                                .HasDatabaseName("IX_Locality_City");

                            b1.ToTable("locality");

                            b1.WithOwner()
                                .HasForeignKey("LocalityId");
                        });

                    b.OwnsOne("senior.domain.ValueObjects.CityState", "State", b1 =>
                        {
                            b1.Property<string>("LocalityId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("CHAR")
                                .HasColumnName("State");

                            b1.HasKey("LocalityId");

                            b1.HasIndex("Value")
                                .HasDatabaseName("IX_Locality_State");

                            b1.ToTable("locality");

                            b1.WithOwner()
                                .HasForeignKey("LocalityId");
                        });

                    b.Navigation("City")
                        .IsRequired();

                    b.Navigation("State")
                        .IsRequired();
                });

            modelBuilder.Entity("senior.domain.Entites.User", b =>
                {
                    b.OwnsOne("senior.domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasDatabaseName("IX_User_Email");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
