namespace RagProject.API.Contracts
{
    public interface IModule
    {
        IEndpointRouteBuilder RegisterEndpoints(
        IEndpointRouteBuilder endpoints);
    }

}
