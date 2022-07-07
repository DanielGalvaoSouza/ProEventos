﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProEventos.Persistence.Contexts;

namespace ProEventos.Persistence.Migrations
{
    [DbContext(typeof(AllDataContext))]
    [Migration("20220625035400_InitialContext")]
    partial class InitialContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ProEventos.Domain.Entities.Auditoriums", b =>
                {
                    b.Property<int>("IdAuditorium")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasBusesToTransportVisitors")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("IdAuditorium");

                    b.ToTable("Auditoriums");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.Events", b =>
                {
                    b.Property<int>("IdEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("DateOfTheEvent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlyerPictureFile")
                        .HasColumnType("TEXT");

                    b.Property<string>("LotOfEvent")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThemeOfEvent")
                        .HasColumnType("TEXT");

                    b.HasKey("IdEvent");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.EventsAndSpeakerOfEvent", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpeakerOfEventId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventId", "SpeakerOfEventId");

                    b.HasIndex("SpeakerOfEventId");

                    b.ToTable("EventsAndSpeakerOfEvents");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.Lot", b =>
                {
                    b.Property<int>("IdLot")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("IdLot");

                    b.HasIndex("EventId");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SpeakerOfEventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SpeakerOfEventId");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.SpeakerOfEvent", b =>
                {
                    b.Property<int>("IdSpeakerOfEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventsIdEvent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("SmallCurriculum")
                        .HasColumnType("TEXT");

                    b.HasKey("IdSpeakerOfEvent");

                    b.HasIndex("EventsIdEvent");

                    b.ToTable("SpeakerOfEvents");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.EventsAndSpeakerOfEvent", b =>
                {
                    b.HasOne("ProEventos.Domain.Entities.Events", "Event")
                        .WithMany("EventsAndSpeakerOfEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Entities.SpeakerOfEvent", "SpeakerOfEvent")
                        .WithMany("EventsAndSpeakerOfEvents")
                        .HasForeignKey("SpeakerOfEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("SpeakerOfEvent");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.Lot", b =>
                {
                    b.HasOne("ProEventos.Domain.Entities.Events", "Event")
                        .WithMany("Lots")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.SocialMedia", b =>
                {
                    b.HasOne("ProEventos.Domain.Entities.Events", "Event")
                        .WithMany("SocialMedias")
                        .HasForeignKey("EventId");

                    b.HasOne("ProEventos.Domain.Entities.SpeakerOfEvent", "SpeakerOfEvent")
                        .WithMany("SocialMedias")
                        .HasForeignKey("SpeakerOfEventId");

                    b.Navigation("Event");

                    b.Navigation("SpeakerOfEvent");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.SpeakerOfEvent", b =>
                {
                    b.HasOne("ProEventos.Domain.Entities.Events", null)
                        .WithMany("SpeakerOfEvents")
                        .HasForeignKey("EventsIdEvent");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.Events", b =>
                {
                    b.Navigation("EventsAndSpeakerOfEvents");

                    b.Navigation("Lots");

                    b.Navigation("SocialMedias");

                    b.Navigation("SpeakerOfEvents");
                });

            modelBuilder.Entity("ProEventos.Domain.Entities.SpeakerOfEvent", b =>
                {
                    b.Navigation("EventsAndSpeakerOfEvents");

                    b.Navigation("SocialMedias");
                });
#pragma warning restore 612, 618
        }
    }
}
