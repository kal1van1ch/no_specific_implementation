namespace CampusRouteLab.Services;

using CampusRouteLab.Models;


public interface IStudentCatalogService {
    public Dictionary<string, List<Student>> GetAllGroups();
    public List<Student>? GetAllStudents(string group);
    public Student? GetStudent(string group, int id);
}