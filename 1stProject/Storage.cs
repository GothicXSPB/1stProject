using System.Globalization;
using System.Text.Json;
using _1stProject.Options;

namespace _1stProject
{
    public class Storage
    {
        Dictionary<int, string> AllCompany { get; set; }
        Dictionary<int, List<int>> AllWorker {get; set; }
        public string _pathAllCompany  { get; set; }
        public string _pathAllWorker { get; set; }

        private static Storage _storage;

        private Storage()
        {
            AllCompany = new Dictionary<int, string>();
            AllWorker = new Dictionary<int, List<int>>();
            _pathAllCompany = @"../InformationAllCompany/AllCompany.txt";
            _pathAllWorker = @"../InformationAllWorker/AllWorker.txt";
        }


        public static Storage GetInstance()
        {
            if (_storage == null)
            {
                _storage = new Storage();
            }
            return _storage;
        }

        public void SaveAllCompany()
        {
            using (StreamWriter sw = new StreamWriter(_pathAllCompany))
            {
                string jsn = JsonSerializer.Serialize(AllCompany);
                sw.WriteLine(jsn);
            }
        }

        public void SaveAllWorker()
        {
            using (StreamWriter sw = new StreamWriter(_pathAllWorker))
            {
                string jsn = JsonSerializer.Serialize(AllWorker);
                sw.WriteLine(jsn);
            }
        }

        public void LoadAllCompany()
        {
            using (StreamReader sr = new StreamReader(_pathAllCompany))
            {
                string jsn = sr.ReadLine()!;
                AllCompany = JsonSerializer.Deserialize<Dictionary<int, string>>(jsn)!;
            }
        }

        public void LoadAllWorker()
        {
            using (StreamReader sr = new StreamReader(_pathAllWorker))
            {
                string jsn = sr.ReadLine()!;
                AllWorker = JsonSerializer.Deserialize<Dictionary<int, List<int>>>(jsn)!;
            }
        }

        public void AddNewCompany(int idCompany, string nameCompany)
        {
            LoadAllCompany();
            AllCompany.Add(idCompany, nameCompany);
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

            AllWorker.Add(idWorker, whatsCompany);

            SaveAllWorker();
        }
    }
}
