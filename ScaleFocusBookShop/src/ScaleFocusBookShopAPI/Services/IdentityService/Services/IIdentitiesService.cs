using IdentityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Services
{
    public interface IIdentitiesService
    {
        bool Authenticate(string username, string passwrord);

        int AddIdentity(Identity identity);
    }
}
