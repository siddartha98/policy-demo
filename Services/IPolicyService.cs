using PolicyDemo.Dtos;

namespace PolicyDemo.Services
{
    /// <summary>
    /// Service contract for policy-related business operations.
    /// The implementation encapsulates data access and domain logic so controllers remain thin.
    /// </summary>
    public interface IPolicyService
    {
        /// <summary>
        /// Returns all policies ordered for display.
        /// Asynchronously retrieves a list from the in-memory database.
        /// </summary>
        Task<IEnumerable<PolicyDto>> GetPoliciesAsync();

        /// <summary>
        /// Adds a new policy to the in-memory database. The service assigns a new PolicyNumber.
        /// </summary>
        Task<PolicyDto> AddPolicyAsync(CreatePolicyDto newPolicy);

        /// <summary>
        /// Attempts to cancel the policy identified by policyNumber.
        /// Returns the updated policy on success or throws exception on error (not found/invalid state).
        /// </summary>
        Task<PolicyDto> CancelPolicyAsync(int policyNumber);
    }
}
