using Stendhal.Client.mobilebase.Helper;
using Stendhal.Client.mobilebase.Services;
using System.Runtime.CompilerServices;

namespace Stendhal.Client.mobilebase.Selectors.interfaces
{
    public interface IApiRequestSelector<T> : IServiceBase
    {
        T GetApiRequestByPriority(IApiRequest<T> apiRequest, PriorityType priorityType, [CallerMemberName] string methodName = "");
    }
}
