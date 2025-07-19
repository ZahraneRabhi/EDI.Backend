using System;
using System.Collections.Generic;
using EDI.Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace EDI.Backend.Data;

public partial class EdiDbContext : DbContext
{
    public EdiDbContext()
    {
    }

    public EdiDbContext(DbContextOptions<EdiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocumentBonCommande> DocumentBonCommandes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ZAHRY\\MSSQLSERVER1;Database=EDIDynamiqueCarino;Integrated Security=True;Trust Server Certificate=yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AI");

        modelBuilder.Entity<DocumentBonCommande>(entity =>
        {
            entity.HasKey(e => e.UniqueId).HasName("PK_DocumentBonCommande_1");

            entity.ToTable("DocumentBonCommande", tb =>
                {
                    tb.HasTrigger("AFTERDelUpdDOCHisto");
                    tb.HasTrigger("AFTERINSERT");
                    tb.HasTrigger("AfterUpdateDBC");
                    tb.HasTrigger("DeletedDetailCommande");
                });

            entity.HasIndex(e => new { e.DocRef, e.DocType }, "DocRefDoctype").IsUnique();

            entity.HasIndex(e => e.DocDate, "IX_DocumentBonCommande_docdate").IsDescending();

            entity.HasIndex(e => e.DocType, "IX_DocumentBonCommande_doctype");

            entity.HasIndex(e => e.DocTiers, "NonClusteredIndex-20161128-134210");

            entity.Property(e => e.UniqueId).HasColumnName("UniqueID");
            entity.Property(e => e.DocAcompte).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DocCloture).HasColumnType("smalldatetime");
            entity.Property(e => e.DocCommentaire)
                .UseCollation("French_CI_AI")
                .HasColumnType("ntext");
            entity.Property(e => e.DocDate).HasColumnType("smalldatetime");
            entity.Property(e => e.DocDateEcheance).HasColumnType("smalldatetime");
            entity.Property(e => e.DocDest)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DocDevise)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DocEtatBp).HasColumnName("DocEtatBP");
            entity.Property(e => e.DocEtatBp1).HasColumnName("DocEtatBP1");
            entity.Property(e => e.DocHliv).HasColumnName("DocHLiv");
            entity.Property(e => e.DocLancement).HasColumnType("smalldatetime");
            entity.Property(e => e.DocMatricule)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DocMntLettre)
                .HasMaxLength(500)
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DocMontant).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.DocNetaPayer).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.DocNptiers)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("DocNPTiers");
            entity.Property(e => e.DocNumDoc)
                .HasMaxLength(15)
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DocRef)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DocRefCaisse)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DocRefExt).HasMaxLength(250);
            entity.Property(e => e.DocRepresentant).HasMaxLength(50);
            entity.Property(e => e.DocReste).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DocTiers)
                .HasMaxLength(20)
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DocTotalHt)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("DocTotalHT");
            entity.Property(e => e.DocTotalRemise).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.DocTotalTva)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("DocTotalTVA");
            entity.Property(e => e.DocType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("French_CI_AI");
            entity.Property(e => e.DocValFodec).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DocValRem).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Ematricule)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("French_CI_AI");
            entity.Property(e => e.MargeMinDoc).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Marque)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Modele).HasMaxLength(50);
            entity.Property(e => e.RefDev)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("French_CI_AI");
            entity.Property(e => e.RefSouDest)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("French_CI_AI");
            entity.Property(e => e.RefSouDest1)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Rmmatricule)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("RMMatricule");
            entity.Property(e => e.TimberFiscal).HasDefaultValue(false);
            entity.Property(e => e.ValeurAvImp)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("Valeur_Av_Imp");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
