using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CodeChallengeAPI
{
    /// <summary>
    /// A model that defines the Quote Response that is returned to the client.
    /// </summary>
    public class QuoteResponse
    {
        /// <summary>
        /// Total Price of Policy
        /// </summary>
        public double Total { get; set; } = 0;

        /// <summary>
        /// Currency code in ISO 4217 format.
        /// </summary>
        public string? Currency_Id { get; set; }

        /// <summary>
        /// Quotation ID for your reference.
        /// </summary>
        public Guid? Quotation_Id { get; set; }
    }
}
