using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinFlow.Core.Entities
{
    public class WorkflowTask
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? RejectReason { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

    }
}