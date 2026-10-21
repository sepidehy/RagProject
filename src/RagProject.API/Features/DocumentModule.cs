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

            endpoints.MapGet("/documents/search", async (string q,
                IDocumentService documentService) =>
            {
                var documents = await documentService.SearchAsync(q);
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
