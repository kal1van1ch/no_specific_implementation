namespace CampusRouteLab.Services;


public class TransientMarkerService : ITransientMarkerService {
    public Guid Id { get; } = Guid.NewGuid();
}