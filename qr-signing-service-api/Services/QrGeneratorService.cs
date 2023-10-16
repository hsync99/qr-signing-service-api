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
            QRCodeGenerator QRGen = new QRCodeGenerator();
            QRCodeData Qrinfo = QRGen.CreateQrCode("mobileSign:" + text + "/token=" +token, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCoder = new QRCode(Qrinfo);
            Bitmap QRbitmap = qRCoder.GetGraphic(50);
            byte[] bitmapArray = bitmaptoArray(QRbitmap);
            return bitmapArray;
        }
        private static byte[] bitmaptoArray(Bitmap bitmapimage)
        {
            using (MemoryStream mstream = new MemoryStream())
            {

                bitmapimage.Save(mstream, ImageFormat.Png);
                return mstream.ToArray();
            }

        }
    }
}
