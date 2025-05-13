using System;

namespace AiAgent.Models;

public class User
{
    public string? Id { get; set; }

    public  string? Email { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string? NationalId { get; set; }

    public string? UserName { get; set; }

    public  string? PhoneNumber { get; set; }

    public string? Avatar { get; set; }

    public bool IsApproved { get; set; } = false;

    public bool? EmailConfirmed { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }

    public bool? TwoFactorEnabled { get; set; }

    public string? Role { get; set; }
    public IList<string>? Roles { get; set; }

    public  string? City { get; set; }

    public string? Address { get; set; }

    public string? SocialMedia { get; set; }

    public string? Gender { get; set; } = "Male";

    public string? LastSessionId { get; set; }
    public DateTime? LastLoginTime { get; set; }
    public DateTime? TokenExpiration { get; set; }
    public string? TokenJti { get; set; }
    public bool? IsActive { get; set; } = false;

    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
