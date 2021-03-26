using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallengeAPI
{
    public class UserCredentials
    {
        /// <summary>
        /// Username to authenticate
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password to authenticate
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
