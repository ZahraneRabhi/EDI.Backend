using EDI.Backend.Contracts;
using EDI.Backend.Data;
using EDI.Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace EDI.Backend.Repositories
{
    public class DBCRepository : BaseRepository<DocumentBonCommande>, IDBCRepository
    {
        public DBCRepository(EdiDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocDateAsync(DateTime docDate)
        {
            return await _context.DocumentBonCommandes.Where(dbc => dbc.DocDate == docDate).ToListAsync();
        }

        public async Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocDestAsync(string docDest)
        {
            return await _context.DocumentBonCommandes.Where(dbc => dbc.DocDest == docDest).ToListAsync();
        }

        public async Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocRefAsync(string docRef)
        {
            return await _context.DocumentBonCommandes.Where(dbc => dbc.DocRef == docRef).ToListAsync();
        }

        public async Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocTiersAsync(string docTiers)
        {
            return await _context.DocumentBonCommandes.Where(dbc => dbc.DocTiers == docTiers).ToListAsync();
        }

        public async Task<IReadOnlyCollection<DocumentBonCommande>> GetByDocTypeAsync(string docType)
        {
            return await _context.DocumentBonCommandes.Where(dbc => dbc.DocType == docType).ToListAsync();
        }
    }
}
