namespace FinFlow.Core.DTOs.Workflow
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? RejectReason { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}