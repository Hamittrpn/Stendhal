using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stendhal.Client.mobile.Endpoints.User
{
    [Headers("Content-Type : application/json")]
    public interface IUserEndpoint
    {
        [Get("/users")]
        Task<List<Models.User>> Get();
    }
}
