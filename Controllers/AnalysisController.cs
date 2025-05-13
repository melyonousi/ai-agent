using AiAgent.Models;
using AiAgent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AiAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController(IPerformanceAgentService _geminiService) : ControllerBase
    {
        [HttpPost("performance")]
        public async Task<IActionResult> AnalyzePerformance([FromBody] PerformanceRequest packagesList)
        {
            Console.WriteLine(packagesList);
            var result = await _geminiService.AnalyzePackagesWithCustomPrompt(packagesList);
            return Ok(new {result});
        }
    }
}
