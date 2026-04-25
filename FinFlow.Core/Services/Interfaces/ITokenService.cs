namespace FinFlow.Core.Services.Interfaces
{
    
    public interface ITokenService
    {
        string CreateToken(Entities.User user);
    }
}