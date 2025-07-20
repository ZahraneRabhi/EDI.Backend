using System.Threading.Tasks;

namespace EDI.Backend.Contracts
{
    public interface IOCRContract
    {
        Task<string> ScanReceiptAsync(byte[] receipt);
    }
}