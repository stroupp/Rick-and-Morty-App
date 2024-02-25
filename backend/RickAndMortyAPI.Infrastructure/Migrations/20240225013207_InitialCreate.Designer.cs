﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RickAndMortyAPI.Infrastructure.Data;

#nullable disable

namespace RickAndMortyAPI.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240225013207_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OriginId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("OriginId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AirDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EpisodeCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.EpisodeCharacter", b =>
                {
                    b.Property<int>("EpisodeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EpisodeId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("EpisodeCharacters");
                });

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Origin");
                });

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.Character", b =>
                {
                    b.HasOne("RickAndMortyAPI.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RickAndMortyAPI.Domain.Entities.Origin", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.Episode", b =>
                {
                    b.HasOne("RickAndMortyAPI.Domain.Entities.Character", null)
                        .WithMany("Episodes")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.EpisodeCharacter", b =>
                {
                    b.HasOne("RickAndMortyAPI.Domain.Entities.Character", "Character")
                        .WithMany("EpisodeCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RickAndMortyAPI.Domain.Entities.Episode", "Episode")
                        .WithMany("EpisodeCharacters")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.Character", b =>
                {
                    b.Navigation("EpisodeCharacters");

                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("RickAndMortyAPI.Domain.Entities.Episode", b =>
                {
                    b.Navigation("EpisodeCharacters");
                });
#pragma warning restore 612, 618
        }
    }
}
