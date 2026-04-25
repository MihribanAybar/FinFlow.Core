using FinFlow.Core.Data;
using FinFlow.Core.DTOs.Workflow;
using FinFlow.Core.Entities;
using FinFlow.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Core.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly AppDbContext _context;

        public WorkflowService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRequest(CreateTaskDto dto, int userId)
        {
            var task = new WorkflowTask
            {
                Title = dto.Title,
                Description = dto.Description,
                Amount = dto.Amount,
                UserId = userId,
                Status = "Pending" 
            };

            _context.WorkflowTasks.Add(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TaskResponseDto>> GetUserRequests(int userId)
        {
            return await _context.WorkflowTasks
                .Where(x => x.UserId == userId)
                .Select(x => new TaskResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Amount = x.Amount,
                    Status = x.Status,
                    RejectReason = x.RejectReason,
                    CreatedAt = x.CreatedAt
                }).ToListAsync();
        }

        public async Task<List<TaskResponseDto>> GetPendingRequests()
        {
            return await _context.WorkflowTasks
                .Where(x => x.Status == "Pending")
                .Select(x => new TaskResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Amount = x.Amount,
                    Status = x.Status,
                    RejectReason = x.RejectReason,
                    CreatedAt = x.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<bool> ApproveRequest(int id, int adminId, string note)
        {
            var task = await _context.WorkflowTasks.FindAsync(id);
            if (task == null || task.Status != "Pending") return false;

            task.Status = "Approved";

            _context.ApprovalHistories.Add(new ApprovalHistory
            {
                WorkflowTaskId = id,
                AdminId = adminId,
                Action = "Approved",
                Note = note
            });

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RejectRequest(int id, int adminId, string reason)
        {
            var task = await _context.WorkflowTasks.FindAsync(id);
            if (task == null || task.Status != "Pending") return false;

            task.Status = "Rejected";
            task.RejectReason = reason;

            _context.ApprovalHistories.Add(new ApprovalHistory
            {
                WorkflowTaskId = id,
                AdminId = adminId,
                Action = "Rejected",
                Note = reason
            });

            return await _context.SaveChangesAsync() > 0;
        }
    }
}