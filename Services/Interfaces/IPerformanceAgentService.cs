using System;
using AiAgent.Models;

namespace AiAgent.Services.Interfaces;

public interface IPerformanceAgentService
{
    Task<string> AnalyzePackagesWithCustomPrompt(PerformanceRequest data);
}
