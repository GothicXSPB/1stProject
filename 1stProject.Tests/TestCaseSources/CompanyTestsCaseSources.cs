using Microsoft.VisualBasic;
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

    public class CalendarCompanyTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Dictionary<int, List<long>> calendar = new Dictionary<int, List<long>>()
            {
                {1, new List<long>() {35423525,23252352356, 946332424363} },
                {67, new List<long>() {725424722341,09091283124, 332294791874298 } },
                {1201, new List<long>() {6161661616,000024140041, 39084725981} }
            };

            yield return new Object[] { calendar };

            yield return new Object[]
            {
                    new Dictionary<int, List<long>>()
            };
        }
    }

    public class DateToNumberDayTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            DateTime thisdate = new DateTime(2021, 5, 12);
            int numberperday = 132;

            yield return new Object[] { numberperday, thisdate };
        }
    }

    //public class CreateTimetableTestsCaseSources : IEnumerable
    //{
    //    public IEnumerator GetEnumerator()
    //    {
    //        DateTime thisdate = new DateTime(2021, 5, 12);
    //        int numberperday = 132;

    //        yield return new Object[] { numberperday, thisdate };
    //    }
    //}
}
