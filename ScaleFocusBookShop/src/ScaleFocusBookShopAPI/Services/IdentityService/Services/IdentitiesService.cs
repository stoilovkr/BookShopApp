using IdentityService.Models;
using IdentityService.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Services
{
    public class IdentitiesService : IIdentitiesService
    {
        private IdentitiesDbContext identitiesDbContext;

        public IdentitiesService(IdentitiesDbContext _identitiesDbContext)
        {
            identitiesDbContext = _identitiesDbContext;
        }

        public bool Authenticate(string user, string passwrord)
        {
            return identitiesDbContext.Identities.SingleOrDefault(x => x.Username == user && x.Password == passwrord) != null;
        }

        public int AddIdentity(Identity identity)
        {
            if(identitiesDbContext.Identities.Any(x => x.Username == identity.Username))
            {
                return -1;
            }

            var newidentity = identitiesDbContext.Add<Identity>(identity);
            identitiesDbContext.SaveChanges();
            return newidentity.Entity.Id;
        }
    }
}
