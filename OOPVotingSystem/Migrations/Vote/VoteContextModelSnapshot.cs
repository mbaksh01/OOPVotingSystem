﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OOPVotingSystem.DAL;

#nullable disable

namespace OOPVotingSystem.Migrations.Vote
{
    [DbContext(typeof(VoteContext))]
    partial class VoteContextModelSnapshot : ModelSnapshot
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

            modelBuilder.Entity("OOPVotingSystem.Models.Election", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Election");
                });

            modelBuilder.Entity("OOPVotingSystem.Models.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AcceptedTerms")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("OOPVotingSystem.Models.Vote", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ElectionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("ElectionId");

                    b.HasIndex("PersonId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("OOPVotingSystem.Models.Candidate", b =>
                {
                    b.HasBaseType("OOPVotingSystem.Models.Person");

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ElectionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PartyId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Candidate");
                });

            modelBuilder.Entity("OOPVotingSystem.Models.Person", b =>
                {
                    b.HasOne("OOPVotingSystem.Models.Address", "Address")
                        .WithMany("People")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("OOPVotingSystem.Models.Vote", b =>
                {
                    b.HasOne("OOPVotingSystem.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OOPVotingSystem.Models.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OOPVotingSystem.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Election");

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
