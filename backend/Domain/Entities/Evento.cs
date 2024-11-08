namespace Domain.Entities;

public partial class Evento : BaseEntity
{
    public string Description { get; set; } = null!;

    public DateTime? DateEvent { get; set; }

    public string? TypeEvent { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
