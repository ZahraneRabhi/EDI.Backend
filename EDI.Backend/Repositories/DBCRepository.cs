using EDI.Backend.Contracts;
using EDI.Backend.Data;
using EDI.Backend.Entities;

namespace EDI.Backend.Repositories
{
    public class DBCRepository : BaseRepository<DocumentBonCommande>, IDBCRepository
    {
        public DBCRepository(EdiDbContext context) : base(context)
        {
        }

        public Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocDateAsync(DateTime docDate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocDestAsync(string docDest)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocRefAsync(string docRef)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocTiersAsync(string docTiers)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocTypeAsync(string docType)
        {
            throw new NotImplementedException();
        }
    }
}
