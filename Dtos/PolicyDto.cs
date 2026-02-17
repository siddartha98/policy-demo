namespace PolicyDemo.Dtos
{
    /// <summary>
    /// DTO returned by the API for Policy resources.
    /// </summary>
    public class PolicyDto
    {
        public int PolicyNumber { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
    }
}
