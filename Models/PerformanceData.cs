using System;

namespace AiAgent.Models;

public class PerformanceRequest
{
    public required List<Package> Data { get; set; } = [];

    public required string Prompt { get; set; }

    public User? CurrentUser { get; set; }
    public List<User>? Users { get; set; }
}
