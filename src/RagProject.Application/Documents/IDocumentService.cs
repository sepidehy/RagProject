using RagProject.Application.Common;
using RagProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RagProject.Application.Documents
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllAsync();

        Task<PagedResult<Document>> SearchAsync(string query, int page = 1, int pageSize = 10);
    }
}
