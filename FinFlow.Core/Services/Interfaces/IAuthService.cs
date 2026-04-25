using FinFlow.Core.DTOs.Auth;

namespace FinFlow.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterDto registerDto);

        Task<string?> Login(LoginDto loginDto);
    }
}