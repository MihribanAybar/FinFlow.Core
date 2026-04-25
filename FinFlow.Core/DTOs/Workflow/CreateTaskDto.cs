namespace FinFlow.Core.DTOs.Workflow
{
    public class CreateTaskDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}