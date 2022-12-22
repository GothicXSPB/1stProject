using System.Globalization;
using System.Text.Json;
using _1stProject.Options;

namespace _1stProject
{
    public class Storage
    {
        public Dictionary<int, string> allCompany = new Dictionary<int, string>();
        public Dictionary<long, List<int>> allWorker = new Dictionary<long, List<int>>();

        public string _pathAllCompany = @"../InformationAllCompany/AllCompany.txt";
        public string _pathAllWorker = @"../InformationAllWorker/AllWorker.txt";

        public void SaveAllCompany()
        {
            using (StreamWriter sw = new StreamWriter(_pathAllCompany))
            {
                string jsn = JsonSerializer.Serialize(allCompany);
                sw.WriteLine(jsn);
            }
        }

        public void SaveAllWorker()
        {
            using (StreamWriter sw = new StreamWriter(_pathAllWorker))
            {
                string jsn = JsonSerializer.Serialize(allWorker);
                sw.WriteLine(jsn);
            }
        }

        public void LoadAllCompany()
        {
            using (StreamReader sr = new StreamReader(_pathAllCompany))
            {
                string jsn = sr.ReadLine()!;
                allCompany = JsonSerializer.Deserialize<Dictionary<int, string>>(jsn)!;
            }
        }

        public void LoadAllWorker()
        {
            using (StreamReader sr = new StreamReader(_pathAllWorker))
            {
                string jsn = sr.ReadLine()!;
                allWorker = JsonSerializer.Deserialize<Dictionary<int, List<int>>>(jsn)!;
            }
        }

        public void AddNewCompany(int idCompany, string nameCompany)
        {
            LoadAllCompany();
            allCompany.Add(idCompany, nameCompany);
            SaveAllCompany();
        }

        public void AddNewWorker(int idWorker, int[] idCompany)
        {
            LoadAllWorker();

            List<int> whatsCompany = new List<int>();

            for (int i = 0; i < idCompany.Length; i++)
            {
                whatsCompany.Add(idCompany[i]);
            }

            allWorker.Add(idWorker, whatsCompany);

            SaveAllWorker();
        }
    }
}
