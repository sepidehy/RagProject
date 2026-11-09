using Microsoft.EntityFrameworkCore;
using RagProject.Application.Common;
using RagProject.Application.Documents;
using RagProject.Domain;
using RagProject.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RagProject.Infrastructure.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly AppDbContext _dbContext;

        public DocumentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _dbContext.Documents
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<PagedResult<Document>> SearchAsync(string query,int page ,int pageSize)
        {
            var queryable = _dbContext.Documents
                .AsNoTracking()
                .Where(d =>
                    d.Title.Contains(query) ||
                    d.Content.Contains(query));

            var totalCount = await queryable.CountAsync();

            var items =  await queryable
                .OrderBy(d => d.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Document> { Items = items , Page = page, PageSize = pageSize, TotalCount = totalCount};
                
        }
    }

}
