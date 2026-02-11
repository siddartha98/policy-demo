
using System.ComponentModel.DataAnnotations;

namespace PolicyDemo.Domain;

public class Policy
{
    [Key]
    public int PolicyNumber { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCancelled { get; set; }
    public DateTime? CancelledDate { get; set; }

    public void Cancel(DateTime cancelledDate)
    {
        if (IsCancelled)
            throw new InvalidOperationException("Policy already cancelled.");

        IsCancelled = true;
        CancelledDate = cancelledDate;
    }
}
