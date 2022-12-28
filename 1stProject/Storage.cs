using System.Globalization;
using System.Linq;
using System.Text.Json;
using _1stProject.Options;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace _1stProject
{
    public class Storage
    {
        public Dictionary<int, string> AllCompany { get; set; }
        public Dictionary<long, List<int>> AllWorker {get; set; }
        public string _pathAllCompany  { get; set; }
        public string _pathAllWorker { get; set; }

        public static Storage _storage;
        Company _company;

        public Storage()
        {
            AllCompany = new Dictionary<int, string>();
            AllWorker = new Dictionary<long, List<int>>();
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
            if (File.Exists(_pathAllCompany))
            {
                using (StreamReader sr = new StreamReader(_pathAllCompany))
                {
                    string jsn = sr.ReadLine()!;
                    AllCompany = JsonSerializer.Deserialize<Dictionary<int, string>>(jsn)!;
                }
            }
            else
            {
                Console.WriteLine("NET FILE");
                throw new DirectoryNotFoundException();
            }
        }

        public void LoadAllWorker()
        {
            if (File.Exists(_pathAllWorker))
            {
                using (StreamReader sr = new StreamReader(_pathAllWorker))
                {
                    string jsn = sr.ReadLine()!;
                    AllWorker = JsonSerializer.Deserialize<Dictionary<long, List<int>>>(jsn)!;
                }
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }
        public void AddNewCompany(int IdCompany, string NameCompany)
        {  
            LoadAllCompany();
            AllCompany.Add(IdCompany, NameCompany);
            SaveAllCompany();
        }

        public void AddNewWorker(long idWorker, List<int> idCompany)
        {
            LoadAllWorker();
            AllWorker.Add(idWorker, idCompany);
            SaveAllWorker();
        }

        public override bool Equals(object? obj)
        {
            return obj is Storage storage && 
                AllCompany.SequenceEqual(storage.AllCompany) && 
                AllWorker.SequenceEqual(storage.AllWorker) && 
                _pathAllCompany == storage._pathAllCompany &&
                _pathAllWorker == storage._pathAllWorker;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AllCompany, AllWorker, _pathAllCompany, _pathAllWorker);
        }
    }
}
 