using qr_signing_service_api.Models;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace qr_signing_service_api.Services
{
    public class QrGeneratorService : IQrGeneratorService
    {
        public async Task<byte[]> GenerateQrCodeImage(string text,string token)
        {
            

            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode("mobileSign:" + text + "/token=" + token, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            return qrCode.GetGraphic(20);

        }
   
    }
}
