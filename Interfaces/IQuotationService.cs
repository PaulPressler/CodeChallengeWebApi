using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallengeAPI
{
    public interface IQuotationService
    {
        Task<QuoteResponse> CalculateQuote(QuoteRequest quoteRequest);
    }
}
