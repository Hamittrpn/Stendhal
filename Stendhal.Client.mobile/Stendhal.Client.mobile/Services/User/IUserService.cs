using Stendhal.Client.mobilebase.Helper;
using Stendhal.Client.mobilebase.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stendhal.Client.mobile.Services.User
{
    public interface IUserService : IServiceBase
    {
        Task<List<Models.User>> Get(PriorityType priorityType);
    }
}
