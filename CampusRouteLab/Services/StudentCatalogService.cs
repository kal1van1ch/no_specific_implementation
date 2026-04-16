namespace CampusRouteLab.Services;

using CampusRouteLab.Models;


public class StudentCatalogService : IStudentCatalogService {
    private Dictionary<string, List<Student>> _listOfGrouos = new Dictionary<string, List<Student>> {
        ["Group_1"] = new List<Student> {
            new Student(1, "Mikhail"),
            new Student(2, "Valya"),
            new Student(3, "Nastya")
        },
        ["Group_2"] = new List<Student> {
            new Student(1, "Denis"),
            new Student(2, "Yulya"),
            new Student(3, "Max")
        }
    };
    public Dictionary<string, int> GetAllGroups() {
        Dictionary<string, int> answer = new Dictionary<string, int>();

        foreach (var elem in _listOfGrouos) {
            string key = elem.Key;
            int length = elem.Value.Count;

            answer.Add(key, length);
        }

        return answer;
    }
    public List<Student>? GetAllStudents(string group) => _listOfGrouos.ContainsKey(group) ? _listOfGrouos[group] : null;
    public Student? GetStudent(string group, int id) => _listOfGrouos.ContainsKey(group) ?
    _listOfGrouos[group].FirstOrDefault(g => g.id == id) : null;
}