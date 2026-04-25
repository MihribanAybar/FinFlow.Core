using FinFlow.Core.DTOs.Auth;
using FinFlow.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinFlow.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AuthController : ControllerBase 
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            var result = await _authService.Register(request);

            if (!result)
            {
                return BadRequest(new { Message = "Bu kullanıcı adı zaten kullanılıyor veya kayıt işlemi başarısız." });
            }

            return Ok(new { Message = "Kullanıcı başarıyla oluşturuldu." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var token = await _authService.Login(request);

            if (token == null)
            {
                return Unauthorized(new { Message = "Geçersiz kullanıcı adı veya şifre." });
            }

            return Ok(new { Token = token, Message = "Giriş başarılı." });
        }
    }
}