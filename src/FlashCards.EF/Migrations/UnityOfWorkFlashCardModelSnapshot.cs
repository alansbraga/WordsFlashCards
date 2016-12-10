using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FlashCards.EF;
using FlashCards.Domain;

namespace FlashCards.EF.Migrations
{
    [DbContext(typeof(UnityOfWorkFlashCard))]
    partial class UnityOfWorkFlashCardModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("FlashCards.Domain.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("FlashCards.Domain.FlashCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<string>("Question");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("FlashCard");
                });

            modelBuilder.Entity("FlashCards.Domain.FlashCardCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CollectionId");

                    b.Property<int?>("FlashCardId");

                    b.Property<int>("Occurrences");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("FlashCardId");

                    b.ToTable("FlashCardCollection");
                });

            modelBuilder.Entity("FlashCards.Domain.Sample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FlashCardId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("FlashCardId");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("FlashCards.Domain.FlashCardCollection", b =>
                {
                    b.HasOne("FlashCards.Domain.Collection")
                        .WithMany("FlashCards")
                        .HasForeignKey("CollectionId");

                    b.HasOne("FlashCards.Domain.FlashCard", "FlashCard")
                        .WithMany()
                        .HasForeignKey("FlashCardId");
                });

            modelBuilder.Entity("FlashCards.Domain.Sample", b =>
                {
                    b.HasOne("FlashCards.Domain.FlashCard")
                        .WithMany("Samples")
                        .HasForeignKey("FlashCardId");
                });
        }
    }
}
