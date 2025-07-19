using System;
using System.Collections.Generic;

namespace EDI.Backend.Entities;

public partial class DocumentBonCommande
{
    public int UniqueId { get; set; }

    public int? DocAnnee { get; set; }

    public string DocType { get; set; } = null!;

    public string DocRef { get; set; } = null!;

    public DateTime? DocDate { get; set; }

    public string? DocTiers { get; set; }

    public decimal? DocTotalHt { get; set; }

    public decimal? DocTotalRemise { get; set; }

    public decimal? DocTotalTva { get; set; }

    public decimal? DocMontant { get; set; }

    public DateTime? DocDateEcheance { get; set; }

    public string? DocRefExt { get; set; }

    public string? DocNumDoc { get; set; }

    public string? DocCommentaire { get; set; }

    public string? DocMntLettre { get; set; }

    public string? DocRepresentant { get; set; }

    public decimal? DocNetaPayer { get; set; }

    public double? DocTauxRem { get; set; }

    public decimal? DocValRem { get; set; }

    public string? DocDevise { get; set; }

    public double? DocTxDevise { get; set; }

    public string? DocMatricule { get; set; }

    public string? DocDest { get; set; }

    public bool? DocEtatBp { get; set; }

    public string? RefDev { get; set; }

    public string? RefSouDest { get; set; }

    public bool? TimberFiscal { get; set; }

    public double? ValTimberFiscal { get; set; }

    public decimal? DocAcompte { get; set; }

    public decimal? DocReste { get; set; }

    public int? DocHliv { get; set; }

    public string? Ematricule { get; set; }

    public string? DocRefCaisse { get; set; }

    public bool? EtatPaye { get; set; }

    public string? Rmmatricule { get; set; }

    public int? NumCloture { get; set; }

    public string? DocNptiers { get; set; }

    public string? Marque { get; set; }

    public string? Modele { get; set; }

    public DateTime? DocLancement { get; set; }

    public DateTime? DocCloture { get; set; }

    public double? DocRetenu { get; set; }

    public int? DocProjet { get; set; }

    public bool? Fodec { get; set; }

    public decimal? DocValFodec { get; set; }

    public bool? DocForfitaire { get; set; }

    public bool? DocEtatBp1 { get; set; }

    public string? RefSouDest1 { get; set; }

    public int? Col5 { get; set; }

    public decimal? MargeMinDoc { get; set; }

    public decimal? ValeurAvImp { get; set; }
}
