using System;
using System.Collections;

namespace _1stProject.Tests.TestCaseSources
{
    public class LoadAllCompanyTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Dictionary<int, string> AllCompany = new Dictionary<int, string>()
            {
                {1, "Lapa" },
                {2, "Velvet and soup" },
                {3, "coFFeeGang" },
                {4, "smokeWeeD_everyDAY" }
            };
            yield return AllCompany;
        }
    }
}
