using ListaSpesa_BackEnd;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Articolo
{
    [Key]
    public int IdArticolo { get; set; }

    public int IdCategoria { get; set; }

    [ForeignKey(nameof(IdCategoria))]
    public Categoria? Categoria { get; set; }

    public string NomeArticolo { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,2)")]
    public decimal PrezzoNormale { get; set; }

    public bool OffertaSiNo { get; set; } = false;

    public bool DaComprareSiNo { get; set; }

    public int Quantità { get; set; }

    public string? NomeNegozio { get; set; }   // <-- ora nullable

    [Column(TypeName = "decimal(10,2)")]
    public decimal? PrezzoOfferta { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? DataScadenzaOfferta { get; set; }

    // NUOVI CAMPI

    public int Priorita { get; set; }   // -1, 0, 1

    public string? UnitaMisura { get; set; }   // "kg", "un.", "l", ecc. — null se non specificata
}