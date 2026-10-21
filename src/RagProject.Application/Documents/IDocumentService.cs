using RagProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RagProject.Application.Documents
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllAsync();

        Task<List<Document>> SearchAsync(string query);
    }
}
