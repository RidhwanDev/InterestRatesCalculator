using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InterestRatesServerless.Tests.Utility
{
    public class TestData : IEnumerable<object[]>
    {
        private IEnumerator<object[]> GetData()
        {
            var result = new List<object[]>();
            
            for (int i = 0; i < 200; i++)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 100000);

                result.Add(new object[] { randomNumber });
            }

            return result.GetEnumerator();
        }


        public IEnumerator<object[]> GetEnumerator() => GetData();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}