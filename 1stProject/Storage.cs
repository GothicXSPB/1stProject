using System.Text.Json;
using _1stProject.Options;

namespace _1stProject
{
    public class Storage
    {
        Dictionary<int, string> allCompany = new Dictionary<int, string>();
        Dictionary<int, List<int>> allWorker = new Dictionary<int, List<int>>();
    }
}
