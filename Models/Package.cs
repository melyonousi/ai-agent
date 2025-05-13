using System;

namespace AiAgent.Models;

public class Package
{
    public Guid? Id { get; set; }

    public string? TrackingId { get; set; }

    public  string? Title { get; set; }

    public string? Note { get; set; }

    public string? Message { get; set; }

    public  decimal Price { get; set; }

    public int? Quantity { get; set; } = 0;

    public Guid CityId { get; set; }
    public string CityName { get; set; } = null!;

    public  decimal ShippingFee { get; set; }

    public  string? DestinationAddress { get; set; }

    public string? DestinationPostalCode { get; set; }

    public  string? DestinationPhoneNumber { get; set; }

    public  string? DestinationFullName { get; set; }

    public string? DestinationEmail { get; set; }

    public string? DestinationLocation { get; set; }

    public DateTime? DestinationExpectedDate { get; set; }

    public  bool AuthorizedToOpen { get; set; } = false;

    public  bool IsPaid { get; set; } = false;

    public  string? Status { get; set; }

    public  string? CreatedById { get; set; }
    public User? CreatedBy { get; set; }

    public Guid? StockId { get; set; }
    public Stock? Stock { get; set; }

    public string? DeliveryId { get; set; }
    public User? Delivery { get; set; }

    public List<History>? History { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
