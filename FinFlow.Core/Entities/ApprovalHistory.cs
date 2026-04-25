using System.ComponentModel.DataAnnotations;

namespace FinFlow.Core.Entities
{
    public class ApprovalHistory
    {
        public int Id { get; set; }

        public int WorkflowTaskId { get; set; }
        public WorkflowTask? WorkflowTask { get; set; }

        public int AdminId { get; set; }

        public string Action { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public DateTime ActionDate { get; set; } = DateTime.Now;
    }
}