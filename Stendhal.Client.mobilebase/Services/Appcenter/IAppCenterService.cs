using Refit;
using System;
using System.Collections.Generic;

namespace Stendhal.Client.mobilebase.Services.Appcenter
{
    public interface IAppCenterService : IServiceBase
    {
        void Init();
        bool HandleApiException(ApiException ex);
        void HandleException(Exception ex);
    }
}
