using System;
using System.Collections;

namespace _1stProject.Tests.TestCaseSources
{
    public class StorageCompanyTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Dictionary<int, string> allCompany = new Dictionary<int, string>()
            {
                {1, "Lapa" },
                {2, "Velvet and soup" },
                {3, "coFFeeGang" },
                {4, "smokeWeeD_everyDAY" }
            };
            yield return new Object[] { allCompany };

            yield return new Object[]
            {
                new Dictionary<int, string>()
            };
        }
    }

    public class StorageWorkerTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Dictionary<long, List<int>> allWorker = new Dictionary<long, List<int>>()
            {
                {132946273, new List<int>() {1, 6, 9} },
                {80202020202020, new List<int>() {2, 6} },
                {10099503, new List<int>() {9, 55, 82544} },
                {8777722, new List<int>() }
            };
            yield return new Object[] { allWorker };

            yield return new Object[]
            {
                new Dictionary<long, List<int>>()
            };
        }
    }
}
