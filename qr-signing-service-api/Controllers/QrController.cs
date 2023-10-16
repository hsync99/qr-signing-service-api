using Microsoft.AspNetCore.Mvc;
using qr_signing_service_api.Models;
using qr_signing_service_api.Services;

using static System.Net.Mime.MediaTypeNames;

namespace qr_signing_service_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QrController : ControllerBase
    {
        IQrGeneratorService _qrService;
        IjwtService _jwtService;
        private const string MimeType = "image/png";
        private const string FileName = "QR.png";
        public QrController(IQrGeneratorService qrService,IjwtService jwtService)
        {
            _qrService = qrService;
            _jwtService = jwtService;

        }   

        [HttpPost]
        [Route("GenerateQR")]
        public async Task<IActionResult> GenerateQRCodeAsync(string qrtext,int workspace_id,string file_uuid)
        {
            Token token = new Token();
            token.DateTime = DateTime.Now.AddMinutes(30);
            token.file_uuid = file_uuid;
            token.workspace_id = workspace_id;

            var jwt =   await _jwtService.GenerateJWT(token);
            var qr  =   await _qrService.GenerateQrCodeImage(qrtext, jwt);

            return File(qr, MimeType, FileName);
           
        }

        
    }
}
