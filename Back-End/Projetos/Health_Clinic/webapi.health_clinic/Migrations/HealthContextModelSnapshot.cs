﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.health_clinic.Contexts;

#nullable disable

namespace webapi.health_clinic.Migrations
{
    [DbContext(typeof(HealthContext))]
    partial class HealthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.health_clinic.Domains.Clinica", b =>
                {
                    b.Property<Guid>("IdClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("CHAR(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<TimeSpan?>("HoraDeAbertura")
                        .IsRequired()
                        .HasColumnType("TIME");

                    b.Property<TimeSpan?>("HoraDeFechamento")
                        .IsRequired()
                        .HasColumnType("TIME");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("IdClinica");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.HasIndex("Endereco")
                        .IsUnique();

                    b.HasIndex("NomeFantasia")
                        .IsUnique();

                    b.HasIndex("RazaoSocial")
                        .IsUnique();

                    b.ToTable("Clinica");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Consulta", b =>
                {
                    b.Property<Guid>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("DATE");

                    b.Property<Guid>("IdClinica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMedico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPresencaConsulta")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdConsulta");

                    b.HasIndex("IdClinica");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdPresencaConsulta");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Especialidade", b =>
                {
                    b.Property<Guid>("IdEspecialidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("IdEspecialidade");

                    b.HasIndex("Titulo")
                        .IsUnique();

                    b.ToTable("Especialidade");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.FeedBacks", b =>
                {
                    b.Property<Guid>("IdFeedBacks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdConsulta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("_FeedBacksIdFeedBacks")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdFeedBacks");

                    b.HasIndex("IdConsulta");

                    b.HasIndex("_FeedBacksIdFeedBacks");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Medico", b =>
                {
                    b.Property<Guid>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<Guid?>("IdClinica")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdEspecialidade")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("IdMedico");

                    b.HasIndex("CRM")
                        .IsUnique();

                    b.HasIndex("IdClinica");

                    b.HasIndex("IdEspecialidade");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Paciente", b =>
                {
                    b.Property<Guid>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("CHAR(11)");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("IdPaciente");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("IdUsuario");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.PresencasConsulta", b =>
                {
                    b.Property<Guid>("IdPresencaConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdPresencaConsulta");

                    b.HasIndex("Situacao")
                        .IsUnique();

                    b.ToTable("PresencasConsulta");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Prontuario", b =>
                {
                    b.Property<Guid>("IdProntuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<Guid>("IdConsulta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdProntuario");

                    b.HasIndex("IdConsulta");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Prontuario");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.TiposDeUsuario", b =>
                {
                    b.Property<Guid>("IdTiposDeUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdTiposDeUsuario");

                    b.HasIndex("Titulo")
                        .IsUnique();

                    b.ToTable("TiposDeUsuario");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<Guid>("IdTipoDeUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("CHAR(60)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdTipoDeUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Consulta", b =>
                {
                    b.HasOne("webapi.health_clinic.Domains.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("IdClinica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.Domains.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.Domains.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.Domains.PresencasConsulta", "PresencaConsulta")
                        .WithMany()
                        .HasForeignKey("IdPresencaConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");

                    b.Navigation("PresencaConsulta");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.FeedBacks", b =>
                {
                    b.HasOne("webapi.health_clinic.Domains.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("IdConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.Domains.FeedBacks", "_FeedBacks")
                        .WithMany()
                        .HasForeignKey("_FeedBacksIdFeedBacks")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");

                    b.Navigation("_FeedBacks");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Medico", b =>
                {
                    b.HasOne("webapi.health_clinic.Domains.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("IdClinica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.Domains.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("IdEspecialidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Especialidade");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Paciente", b =>
                {
                    b.HasOne("webapi.health_clinic.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Prontuario", b =>
                {
                    b.HasOne("webapi.health_clinic.Domains.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("IdConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webapi.health_clinic.Domains.Usuario", b =>
                {
                    b.HasOne("webapi.health_clinic.Domains.TiposDeUsuario", "TipoDeUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoDeUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDeUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}