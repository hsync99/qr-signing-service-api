using qr_signing_service_api.Models;

namespace qr_signing_service_api.Services
{
    public interface IQrGeneratorService
    {
        Task<byte[]> GenerateQrCodeImage(string text,string token);
        
    }
}
