using FinFlow.Core.DTOs.Workflow;
using FinFlow.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinFlow.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;

        public WorkflowController(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }

        private int GetUserId()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(userIdStr!);
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateRequest(CreateTaskDto request)
        {
            var userId = GetUserId(); 
            var result = await _workflowService.CreateRequest(request, userId);

            if (!result) return BadRequest(new { Message = "Talep oluşturulurken bir hata meydana geldi." });
            return Ok(new { Message = "Transfer talebi başarıyla oluşturuldu." });
        }


        [HttpGet("my-requests")]
        public async Task<IActionResult> GetMyRequests()
        {
            var userId = GetUserId();
            var requests = await _workflowService.GetUserRequests(userId);
            return Ok(requests);
        }


        [Authorize(Roles = "Admin")] 
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingRequests()
        {
            var requests = await _workflowService.GetPendingRequests();
            return Ok(requests);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveRequest(int id, [FromBody] string note)
        {
            var adminId = GetUserId();
            var result = await _workflowService.ApproveRequest(id, adminId, note);

            if (!result) return BadRequest(new { Message = "Talep onaylanamadı. Bulunamadı veya zaten işlenmiş olabilir." });
            return Ok(new { Message = "Talep başarıyla onaylandı." });
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectRequest(int id, [FromBody] string reason)
        {
            var adminId = GetUserId();
            var result = await _workflowService.RejectRequest(id, adminId, reason);

            if (!result) return BadRequest(new { Message = "Talep reddedilemedi." });
            return Ok(new { Message = "Talep reddedildi." });
        }
    }
}