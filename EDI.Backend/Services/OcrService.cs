using EDI.Backend.Contracts;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EDI.Backend.Services
{
    public class OCRService : IOCRContract
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public OCRService(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<string> ScanReceiptAsync(byte[] receipt)
        {
            var client = _httpClientFactory.CreateClient();
            var ocrApiUrl = _configuration.GetValue<string>("OCRApiUrl") + "/predict";

            using var content = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(receipt);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            content.Add(fileContent, "file", "receipt.jpg");

            var response = await client.PostAsync(ocrApiUrl, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}