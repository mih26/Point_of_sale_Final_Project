using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using MudBlazor;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Rendering;
using ZXing.Windows.Compatibility;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        
        private readonly IWebHostEnvironment env;
        public  TestsController(IWebHostEnvironment env){
            this.env = env;
        }
        public ActionResult Get()
        {

            //Byte[] byteArray;
            var writer = new BarcodeWriter
            {
                Renderer = new AlternateBitmapRenderer(),
                Format = BarcodeFormat.CODE_128
            };
            Bitmap bitmap = writer.Write(Guid.NewGuid().ToString());
            var fs = new FileStream(Path.Combine(this.env.WebRootPath, "barcodes", Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".png"), FileMode.Create);
            bitmap.Save(fs, ImageFormat.Png);
            fs.Close();
            //BarcodeWriterPixelData w = new BarcodeWriterPixelData()
            //{
            //    Format = BarcodeFormat.CODE_128,
            //    Options = new ZXing.Common.EncodingOptions { Width = 250, Height = 100, Margin = 0 }
            //};

            //var pixelData = w.Write(Guid.NewGuid().ToString());
            //using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed))
            //{
            //    using (var fs = new FileStream(Path.Combine(this.env.WebRootPath, "barcodes", Path.GetFileNameWithoutExtension(Path.GetRandomFileName())+".png"), FileMode.Create))
            //    {
            //        var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            //        try
            //        {
            //            // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
            //            System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            //        }
            //        finally
            //        {
            //            bitmap.UnlockBits(bitmapData);
            //        }
            //        // save to stream as PNG
            //        bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            //        fs.Close();
                    
            //    }
            //}

            return Ok();
        }
    }
}
