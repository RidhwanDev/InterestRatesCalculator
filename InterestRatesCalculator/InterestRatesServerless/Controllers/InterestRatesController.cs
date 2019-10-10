using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InterestRatesServerless.Controllers
{
    [Route("api/[controller]")]
    public class InterestRatesController : Controller
    {
        // GET api/interestRates/500
        [HttpGet("{balance}")]
        public decimal Get(decimal balance)
        {
            decimal result;
            if(balance < 1000)
            {
                result = balance * 0.01m;
            }
            else if(balance >= 1000 && balance < 5000)
            {
                result =  balance * 0.015m;
            }
            else if (balance >= 5000 && balance < 10000)
            {
                result =  balance * 0.02m;
            }
            else
            {
                result =  balance * 0.03m;
            }

            return Math.Round(result, 2);
        }
    }
}
