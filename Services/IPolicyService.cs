using PolicyDemo.Domain;

namespace PolicyDemo.Services
{
    public interface IPolicyService
    {
        Task<IEnumerable<Policy>> GetPoliciesAsync();

        Task<Policy> CancelPolicyAsync(int policyNumber);
    }
}
