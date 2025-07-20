using EDI.Backend.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace EDI.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        private readonly IOCRContract _ocrService;

        public OcrController(IOCRContract ocrService)
        {
            _ocrService = ocrService;
        }

        [HttpPost("scan")]
        public async Task<IActionResult> ScanReceipt([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var bytes = ms.ToArray();

            var ocrResult = await _ocrService.ScanReceiptAsync(bytes);
            return Content(ocrResult, "application/json");
        }
    }
}