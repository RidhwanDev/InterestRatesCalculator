using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using Newtonsoft.Json;

using InterestRatesServerless;
using InterestRatesServerless.Tests.Utility;
using System.Diagnostics;

namespace InterestRatesServerless.Tests
{
    public class ValuesControllerTests
    {
        [Theory]
        [ClassData(typeof(TestData))]
        public async Task TestGet(decimal balance)
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/ValuesController-Get.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            request.PathParameters["proxy"] += balance;

            var context = new TestLambdaContext();
            var response = await lambdaFunction.FunctionHandlerAsync(request, context);

            var result = JsonConvert.DeserializeObject<decimal>(response.Body);

            Debug.WriteLine($"Balance: { balance } - Interest Rate: { result }");


            if (balance < 1000)
            {
                Assert.Equal(result, Math.Round(balance * 0.01m, 2));
            }
            else if (balance >= 1000 && balance < 5000)
            {
                Assert.Equal(result, Math.Round(balance * 0.015m, 2));
            }
            else if (balance >= 5000 && balance < 10000)
            {
                Assert.Equal(result, Math.Round(balance * 0.02m, 2));
            }
            else
            {
                Assert.Equal(result, Math.Round(balance * 0.03m, 2));
            }
        }


    }
}
