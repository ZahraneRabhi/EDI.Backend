using EDI.Backend.Entities;

namespace EDI.Backend.Contracts
{
    public interface IDBCRepository : IAsyncRepository<DocumentBonCommande>
    {   Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocTypeAsync(string docType);
        Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocRefAsync(string docRef);
        Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocDateAsync(DateTime docDate);
        Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocTiersAsync(string docTiers);
        Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocDestAsync(string docDest);
    }
}
