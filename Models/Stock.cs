using System;

namespace AiAgent.Models;

public class Stock
{
    public Guid? Id { get; set; }

    public  string? UserId { get; set; }
    public User? User { get; set; }

    public  string? Name { get; set; }

    public  string? Address { get; set; }

    public string? Note { get; set; }

    public  int Quantity { get; set; }

    public  decimal PricePerUnit { get; set; }

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
