using EDI.Backend.Contracts;
using EDI.Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EDI.Backend.Controllers
{
    /// <summary>
    /// API controller for managing Document Bon Commande (DBC) records.
    /// Provides endpoints for CRUD operations and queries by specific document fields.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DBCController : ControllerBase
    {
        private readonly IDBCRepository _dbcRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBCController"/> class.
        /// </summary>
        /// <param name="dbcRepository">Repository for accessing DBC data.</param>
        public DBCController(IDBCRepository dbcRepository)
        {
            _dbcRepository = dbcRepository;
        }

        /// <summary>
        /// Retrieves all DBC records.
        /// </summary>
        /// <remarks>
        /// GET: api/DBC
        /// </remarks>
        /// <returns>Returns a list of all DBC records.</returns>
        /// <response code="200">Returns the list of DBC records.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _dbcRepository.ListAllAsync();
            return Ok(items);
        }

        /// <summary>
        /// Retrieves a specific DBC record by its unique identifier.
        /// </summary>
        /// <remarks>
        /// GET: api/DBC/{id}
        /// </remarks>
        /// <param name="id">The unique identifier of the DBC record.</param>
        /// <returns>Returns the DBC record if found.</returns>
        /// <response code="200">Returns the requested DBC record.</response>
        /// <response code="404">If no record is found with the specified ID.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _dbcRepository.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        /// <summary>
        /// Creates a new DBC record.
        /// </summary>
        /// <remarks>
        /// POST: api/DBC
        /// </remarks>
        /// <param name="entity">The DBC entity to create.</param>
        /// <returns>Returns the created DBC record.</returns>
        /// <response code="201">Returns the newly created record.</response>
        /// <response code="400">If the provided entity is null or invalid.</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocumentBonCommande entity)
        {
            if (entity == null)
                return BadRequest();

            var created = await _dbcRepository.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.UniqueId }, created);
        }

        /// <summary>
        /// Updates an existing DBC record.
        /// </summary>
        /// <remarks>
        /// PUT: api/DBC/{id}
        /// </remarks>
        /// <param name="id">The unique identifier of the DBC record to update.</param>
        /// <param name="entity">The updated DBC entity.</param>
        /// <returns>No content if the update is successful.</returns>
        /// <response code="204">Record updated successfully.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="404">If the record does not exist.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DocumentBonCommande entity)
        {
            if (entity == null || entity.UniqueId != id)
                return BadRequest();

            var existing = await _dbcRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _dbcRepository.UpdateAsync(entity);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific DBC record.
        /// </summary>
        /// <remarks>
        /// DELETE: api/DBC/{id}
        /// </remarks>
        /// <param name="id">The unique identifier of the DBC record to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
        /// <response code="204">Record deleted successfully.</response>
        /// <response code="404">If the record does not exist.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _dbcRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _dbcRepository.DeleteAsync(existing);
            return NoContent();
        }

        /// <summary>
        /// Retrieves DBC records by document type.
        /// </summary>
        /// <remarks>
        /// GET: api/DBC/docType/{docType}
        /// </remarks>
        /// <param name="docType">The document type to filter by.</param>
        /// <returns>Returns a list of DBC records matching the specified document type.</returns>
        /// <response code="200">Returns matching records.</response>
        [HttpGet("docType/{docType}")]
        public async Task<IActionResult> GetByDocType(string docType)
        {
            var result = await _dbcRepository.GetByDocTypeAsync(docType);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves DBC records by document reference.
        /// </summary>
        /// <remarks>
        /// GET: api/DBC/docRef/{docRef}
        /// </remarks>
        /// <param name="docRef">The document reference to filter by.</param>
        /// <returns>Returns a list of DBC records matching the specified document reference.</returns>
        /// <response code="200">Returns matching records.</response>
        [HttpGet("docRef/{docRef}")]
        public async Task<IActionResult> GetByDocRef(string docRef)
        {
            var result = await _dbcRepository.GetByDocRefAsync(docRef);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves DBC records by document date.
        /// </summary>
        /// <remarks>
        /// GET: api/DBC/docDate/{docDate}
        /// </remarks>
        /// <param name="docDate">The document date to filter by.</param>
        /// <returns>Returns a list of DBC records created on the specified date.</returns>
        /// <response code="200">Returns matching records.</response>
        [HttpGet("docDate/{docDate}")]
        public async Task<IActionResult> GetByDocDate(DateTime docDate)
        {
            var result = await _dbcRepository.GetByDocDateAsync(docDate);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves DBC records by document tiers.
        /// </summary>
        /// <remarks>
        /// GET: api/DBC/docTiers/{docTiers}
        /// </remarks>
        /// <param name="docTiers">The document tiers to filter by.</param>
        /// <returns>Returns a list of DBC records matching the specified tiers.</returns>
        /// <response code="200">Returns matching records.</response>
        [HttpGet("docTiers/{docTiers}")]
        public async Task<IActionResult> GetByDocTiers(string docTiers)
        {
            var result = await _dbcRepository.GetByDocTiersAsync(docTiers);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves DBC records by document destination.
        /// </summary>
        /// <remarks>
        /// GET: api/DBC/docDest/{docDest}
        /// </remarks>
        /// <param name="docDest">The document destination to filter by.</param>
        /// <returns>Returns a list of DBC records matching the specified destination.</returns>
        /// <response code="200">Returns matching records.</response>
        [HttpGet("docDest/{docDest}")]
        public async Task<IActionResult> GetByDocDest(string docDest)
        {
            var result = await _dbcRepository.GetByDocDestAsync(docDest);
            return Ok(result);
        }
    }
}
