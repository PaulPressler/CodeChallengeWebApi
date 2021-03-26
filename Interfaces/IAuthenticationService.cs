using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallengeAPI
{
    public interface IAuthenticationService
    {
        string Authenticate(string username, string password);
    }
}
