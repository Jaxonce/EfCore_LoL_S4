﻿// <auto-generated />
using System;
using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameWorkLib.Migrations
{
    [DbContext(typeof(LolContext))]
    [Migration("20230326210027_MyMigration")]
    partial class MyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("EntityFrameWorkLib.ChampionEntity", b =>
                {
                    b.Property<int>("UniqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<int>("Class")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SkillEntityName")
                        .HasColumnType("TEXT");

                    b.HasKey("UniqueId");

                    b.HasIndex("SkillEntityName");

                    b.ToTable("Champions");
                });

            modelBuilder.Entity("EntityFrameWorkLib.LargeImageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Base64")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("championId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("championId")
                        .IsUnique();

                    b.ToTable("LargeImage");
                });

            modelBuilder.Entity("EntityFrameWorkLib.RuneEntity", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("RuneFamily")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Runes");
                });

            modelBuilder.Entity("EntityFrameWorkLib.RunePageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChampionEntityUniqueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RuneEntityName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChampionEntityUniqueId");

                    b.HasIndex("RuneEntityName");

                    b.ToTable("RunesPage");
                });

            modelBuilder.Entity("EntityFrameWorkLib.SkillEntity", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("SkillType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("EntityFrameWorkLib.SkinEntity", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ChampionEntityUniqueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Name");

                    b.HasIndex("ChampionEntityUniqueId");

                    b.ToTable("Skins");
                });

            modelBuilder.Entity("EntityFrameWorkLib.ChampionEntity", b =>
                {
                    b.HasOne("EntityFrameWorkLib.SkillEntity", null)
                        .WithMany("champions")
                        .HasForeignKey("SkillEntityName");
                });

            modelBuilder.Entity("EntityFrameWorkLib.LargeImageEntity", b =>
                {
                    b.HasOne("EntityFrameWorkLib.ChampionEntity", "champion")
                        .WithOne("LargeImage")
                        .HasForeignKey("EntityFrameWorkLib.LargeImageEntity", "championId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("champion");
                });

            modelBuilder.Entity("EntityFrameWorkLib.RunePageEntity", b =>
                {
                    b.HasOne("EntityFrameWorkLib.ChampionEntity", null)
                        .WithMany("ListRunePages")
                        .HasForeignKey("ChampionEntityUniqueId");

                    b.HasOne("EntityFrameWorkLib.RuneEntity", null)
                        .WithMany("ListRunePages")
                        .HasForeignKey("RuneEntityName");
                });

            modelBuilder.Entity("EntityFrameWorkLib.SkinEntity", b =>
                {
                    b.HasOne("EntityFrameWorkLib.ChampionEntity", null)
                        .WithMany("Skins")
                        .HasForeignKey("ChampionEntityUniqueId");
                });

            modelBuilder.Entity("EntityFrameWorkLib.ChampionEntity", b =>
                {
                    b.Navigation("LargeImage");

                    b.Navigation("ListRunePages");

                    b.Navigation("Skins");
                });

            modelBuilder.Entity("EntityFrameWorkLib.RuneEntity", b =>
                {
                    b.Navigation("ListRunePages");
                });

            modelBuilder.Entity("EntityFrameWorkLib.SkillEntity", b =>
                {
                    b.Navigation("champions");
                });
#pragma warning restore 612, 618
        }
    }
}