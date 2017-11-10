using CountingKs.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.Stores
{
    public interface IUserStore : IAddable<AuthToken>
    {
        IEnumerable<ApiUser> GetApiUsers();
        AuthToken GetAuthToken(string token);
    }
}
