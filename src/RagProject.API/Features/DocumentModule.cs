using RagProject.API.Contracts;
using RagProject.Application.Documents;

namespace RagProject.API.Features
{
    public class DocumentModule : IModule
    {
        public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/documents", async (IDocumentService documentService) =>
            {
                var documents = await documentService.GetAllAsync();

                return Results.Ok(documents);
            });

            endpoints.MapGet("/documents/search", async (string q,IDocumentService documentService, int page = 1, int pageSize = 10) =>
            {
                if (string.IsNullOrWhiteSpace(q))
                    return Results.BadRequest("Search query is required.");

                if (page <= 0 || pageSize <= 0 || pageSize > 100)
                    return Results.BadRequest("Invalid pagination parameters.");

                var documents = await documentService.SearchAsync(q, page, pageSize);

                return Results.Ok(documents);
            });

            //endpoints.MapGet("/test-error", () =>
            //{
            //    throw new Exception("Something went wrong");

            //    //throw new AppException(
            //    //    "Document not found",
            //    //    HttpStatusCode.NotFound);
            //});

            return endpoints;

        }
    }

}
