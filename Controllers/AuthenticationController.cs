using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallengeAPI.Controllers
{
    [EnableCors("_corsPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Validates provided User Credentials.
        /// </summary>
        /// <param name="userCred">User cred object</param>
        /// <returns>A string containing a JWT.</returns>
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials userCred)
        {
            try
            {
                var token = _authenticationService.Authenticate(userCred.Username, userCred.Password);

                if (token == null)
                    return Unauthorized("The provided Username and Password combination are unauthorized.");
                return Ok(token);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
