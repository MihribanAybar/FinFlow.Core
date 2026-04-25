using FinFlow.Core.DTOs.Workflow;

namespace FinFlow.Core.Services.Interfaces
{
    public interface IWorkflowService
    {
        Task<bool> CreateRequest(CreateTaskDto dto, int userId);
        Task<List<TaskResponseDto>> GetUserRequests(int userId);

        Task<List<TaskResponseDto>> GetPendingRequests();
        Task<bool> ApproveRequest(int id, int adminId, string note);
        Task<bool> RejectRequest(int id, int adminId, string reason);
    }
}