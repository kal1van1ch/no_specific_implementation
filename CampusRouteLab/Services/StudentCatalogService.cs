namespace CampusRouteLab.Services;

using CampusRouteLab.Models;


public class StudentCatalogService : IStudentCatalogService {
    private Dictionary<string, List<Student>> _listOfGrouos = new Dictionary<string, List<Student>> {
        ["Group_1"] = new List<Student> { new Student(0, "Mikhail"), new Student(1, "Denis"), new Student(2, "Yulya") },
        ["Group_2"] = new List<Student> { new Student(0, "Valya"), new Student(1, "Nastya"), new Student(2, "Max") },
    };
    public Dictionary<string, List<Student>> GetAllGroups() => _listOfGrouos;
    public List<Student>? GetAllStudents(string group) => _listOfGrouos.ContainsKey(group) ? _listOfGrouos[group] : null;
    public Student? GetStudent(string group, int id) => _listOfGrouos.ContainsKey(group) ?
    _listOfGrouos[group].FirstOrDefault(g => g.id == id) : null;
}