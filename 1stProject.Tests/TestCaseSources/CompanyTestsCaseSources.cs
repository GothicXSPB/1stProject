using NUnit.Framework;
using System;
using System.Collections;

namespace _1stProject.Tests.TestCaseSources
{
    public class IdAdminsCompanyTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<long> idAdmins = new List<long>() { 2205720832, 23652367582, 043040603456, 2638762863, 888882222, 0000000000 };
            yield return new Object[] { idAdmins };

            yield return new Object[]
            {
                    new List<long>()
            };
        }
    }

    public class IdEmployeesCompanyTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<long> idEmployees = new List<long>() { 72856842, 34626042441, 0000000000, 62371649148, 22282822292, 7737374652222 };
            yield return new Object[] { idEmployees };

            yield return new Object[]
            {
                    new List<long>()
            };
        }
    }
}
