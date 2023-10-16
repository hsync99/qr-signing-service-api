using qr_signing_service_api.Models;

namespace qr_signing_service_api.Services
{
    public interface IjwtService
    {
        Task<string> GenerateJWT(Token tokenjwt);
    }
}
