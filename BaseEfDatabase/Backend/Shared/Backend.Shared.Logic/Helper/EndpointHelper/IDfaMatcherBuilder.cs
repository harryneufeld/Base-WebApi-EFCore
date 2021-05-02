using Microsoft.AspNetCore.Routing;

namespace Backend.Shared.Logic.Helper.EndpointHelper
{
    public interface IDfaMatcherBuilder
    {
        void AddEndpoint(RouteEndpoint endpoint);
        object BuildDfaTree(bool includeLabel = false);
    }
}
