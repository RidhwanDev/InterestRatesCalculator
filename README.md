# InterestRatesCalculator
Please clone to Visual Studio 2017/2019

This solution consists of two projects, the former being an AWS serverless web API project and the latter is it's respective Test Project.
This TDD piece uses xUnit to generate 200 random numbers between 0 and 100,000 using the Thoery method. It calls the API with the given variable and then asserts the values.

This api will also be publicly available for a short while at:

https://mk6kyi0446.execute-api.eu-west-1.amazonaws.com/Prod/api/interestRates/{balance}

An example call would be:

https://mk6kyi0446.execute-api.eu-west-1.amazonaws.com/Prod/api/interestRates/500

Please feel free to review the code and run tests using the visual studio IDE and also to make calls to the API either via your browser or postman and such like.

Thank you.
