using System;

namespace AiAgent.Models;

public class History
{
    public Guid? Id { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public DateTime? ChangedAt { get; set; }

    public Guid? PackageId { get; set; }

    public string? ChangedById { get; set; }
    public virtual User? ChangedBy { get; set; }
}
