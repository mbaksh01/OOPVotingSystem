﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OOPVotingSystem.DAL;

#nullable disable

namespace OOPVotingSystem.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("OOPVotingSystem.Models.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street2")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("OOPVotingSystem.Models.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AcceptedTerms")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("UniquePersonIdentifier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Verified")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("OOPVotingSystem.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Username");

                    b.HasIndex("PersonId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OOPVotingSystem.Models.Person", b =>
                {
                    b.HasOne("OOPVotingSystem.Models.Address", "Address")
                        .WithMany("People")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("OOPVotingSystem.Models.User", b =>
                {
                    b.HasOne("OOPVotingSystem.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("OOPVotingSystem.Models.Address", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
