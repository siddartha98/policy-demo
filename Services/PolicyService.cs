using Microsoft.EntityFrameworkCore;
using PolicyDemo.Data;
using PolicyDemo.Domain;

namespace PolicyDemo.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PolicyService> _logger;

        public PolicyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetPoliciesAsync()
        {
            var policies = await _context.Policies
            .OrderByDescending(p => p.StartDate)
            .ToListAsync();

            return policies;
        }

        public async Task<Policy> CancelPolicyAsync(int policyNumber)
        {
            if (policyNumber <= 0)
                throw new ArgumentException("Invalid policy number.", nameof(policyNumber));
                _logger.LogWarning($"Attempted to cancel by invalid policy number.");

            var policy = await _context.Policies.FirstOrDefaultAsync(p => p.PolicyNumber == policyNumber);

            if (policy == null)
                throw new KeyNotFoundException($"Policy {policyNumber} was not found.");
                _logger.LogWarning($"Attempted to cancel non-existent policy {policyNumber}.");

            if (policy.IsCancelled == true)
                throw new InvalidOperationException($"Policy {policyNumber} is already cancelled.");
                _logger.LogWarning($"Attempted to cancel already cancelled policy {policyNumber}.");

            try
            {
                policy.Cancel(DateTime.UtcNow);
                await _context.SaveChangesAsync();

                return policy;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, $"Concurrency error while cancelling policy {policyNumber}.");
                throw new InvalidOperationException($"Policy {policyNumber} was modified by another process.", ex);
            }
        }
    }
}
