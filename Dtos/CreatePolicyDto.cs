namespace PolicyDemo.Dtos
{
    /// <summary>
    /// DTO used when creating a new policy via API.
    /// PolicyNumber is assigned by server, IsCancelled/CancelledDate are managed server-side.
    /// </summary>
    public class CreatePolicyDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
