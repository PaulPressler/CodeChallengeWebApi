using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace CodeChallengeAPI
{
    public class QuotationService : IQuotationService
    {
        public async Task<QuoteResponse> CalculateQuote(QuoteRequest quoteRequest) 
        {
            try
            {
                // Validate Ages
                if (quoteRequest.Age.FirstOrDefault() < 18)
                {
                    throw new ArgumentException("First age value must be 18 or over.");
                }
                if (!quoteRequest.Age.All(X => X > 0))
                {
                    throw new ArgumentException("Ages 0 or below are not valid.");
                }

                // Validate Dates
                if (quoteRequest.Start_Date > quoteRequest.End_Date)
                {
                    throw new ArgumentException("Start_Date must precede End_Date.");
                }
                if (quoteRequest.Start_Date < DateTime.Now.AddDays(-1) || quoteRequest.End_Date < DateTime.Now.AddDays(-1))
                {
                    throw new ArgumentException("Start_Date and End_Date must be a current or future date.");
                }

                // Validate the currency_id is alpha only
                if (!new Regex("^[a-zA-Z]*$").IsMatch(quoteRequest.Currency_Id))
                {
                    throw new ArgumentException("Currency_Id must only contain alpha characters, A-Z.");
                }

                QuoteResponse quoteResponse = new QuoteResponse() { Total = 0, Currency_Id = quoteRequest.Currency_Id, Quotation_Id = Guid.NewGuid()};

                int tripDurationInDays = (int)(quoteRequest.End_Date - quoteRequest.Start_Date).Value.TotalDays + 1;
                int fixedRate = 3;
                List<double> ageLoads = new List<double>();

                //Loop over the list of ages and build a list of age loads
                foreach (var age in quoteRequest.Age)
                {
                    if (age >= 18 && age <= 30) ageLoads.Add(0.6);      // Age 18 - 30
                    else if (age >= 31 && age <= 40) ageLoads.Add(0.7); // Age 31 - 40
                    else if (age >= 41 && age <= 50) ageLoads.Add(0.8); // Age 41 - 50
                    else if (age >= 51 && age <= 60) ageLoads.Add(0.9); // Age 51 - 60
                    else if (age >= 61 && age <= 70) ageLoads.Add(1);   // Age 61 - 70
                    // Ages under 18 or over 70 cannot be insured
                    else throw new ArgumentOutOfRangeException("Cannot convert age to an age load. Ages under 18 or over 70 cannot be insured.");
                }

                // Calculate the total
                foreach (var ageLoad in ageLoads)
                {
                    quoteResponse.Total += (fixedRate * ageLoad * tripDurationInDays);
                }

                // Round the total to two decimal places
                quoteResponse.Total = Math.Round(quoteResponse.Total, 2);

                return quoteResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
