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

    public class AddCompanyTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int a = 7;
            string b = "Umbrella";
            Dictionary<int, string> allCompany = new Dictionary<int, string>()
            {
                {1, "Lapa" },
                {2, "Velvet and soup" },
                {3, "coFFeeGang" },
                {4, "smokeWeeD_everyDAY" }
            };
            Dictionary<int, string> newAllCompany = new Dictionary<int, string>()
            {
                {1, "Lapa" },
                {2, "Velvet and soup" },
                {3, "coFFeeGang" },
                {4, "smokeWeeD_everyDAY" }
            };

            newAllCompany.Add(a, b);

            yield return new Object[] { allCompany, newAllCompany, a, b };
        }
    }

    public class AddWorkerTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            long a = 77300000140014;
            List<int> b = new List<int>() { 1, 423, 35, 02846238 };
            Dictionary<long, List<int>> allWorker = new Dictionary<long, List<int>>()
            {
                {132946273, new List<int>() {1, 6, 9} },
                {80202020202020, new List<int>() {2, 6} },
                {10099503, new List<int>() {9, 55, 82544} },
                {8777722, new List<int>() }
            };
            Dictionary<long, List<int>> newAllWorker = new Dictionary<long, List<int>>()
            {
                {132946273, new List<int>() {1, 6, 9} },
                {80202020202020, new List<int>() {2, 6} },
                {10099503, new List<int>() {9, 55, 82544} },
                {8777722, new List<int>() }
            };

            newAllWorker.Add(a, b);

            yield return new Object[] { allWorker, newAllWorker, a, b };
        }
    }
}
