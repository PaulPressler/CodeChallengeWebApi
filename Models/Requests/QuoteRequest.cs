using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace CodeChallengeAPI
{
    /// <summary>
    /// A model that defines the quote request from the client.
    /// </summary>
    public class QuoteRequest
    {
        /// <summary>
        /// Comma separated list of insureds’ ages.
        /// </summary>
        [Required]
        [MinLength(1)]
        public List<int> Age { get; set; }

        /// <summary>
        /// Currency code in ISO 4217 format (3 characters).
        /// </summary>
        [Required]
        [StringLength(3, ErrorMessage = "Currency_Id must be a 3 character ISO 4217 currency code."), MinLength(3, ErrorMessage ="Currency_Id must be a 3 character ISO 4217 currency code.")]
        public string Currency_Id { get; set; }

        /// <summary>
        /// Start date of trip in ISO 8601 format.
        /// </summary>
        [Required]
        [NotNull]
        public DateTime? Start_Date { get; set; } = null;

        /// <summary>
        /// End date of trip in ISO 8601 format.
        /// </summary>
        [Required]
        [NotNull]
        public DateTime? End_Date { get; set; } = null;
    }
}
