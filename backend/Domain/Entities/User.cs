namespace Domain.Entities;

public partial class User : BaseEntity
{
    public string UserName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? DateCreation { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = [];
}
