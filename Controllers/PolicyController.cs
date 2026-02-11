
using Microsoft.AspNetCore.Mvc;
using PolicyDemo.Services;

namespace PolicyDemo.Controllers;

[ApiController]
[Route("api/policies")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyService _policyService;
    private readonly ILogger<PolicyController> _logger;

    public PolicyController(IPolicyService policyService, ILogger<PolicyController> logger)
    {
        _policyService = policyService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetPolicies()
    {
        try
        {
            var result = await _policyService.GetPoliciesAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{policyNumber}/cancel")]
    public async Task<IActionResult> CancelPolicy(int policyNumber)
    {
        try
        {
            var result = await _policyService.CancelPolicyAsync(policyNumber);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
