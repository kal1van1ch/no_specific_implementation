namespace CampusHub.ConfigCenter.Configurations;


public class TextConfigurationSource : IConfigurationSource {
    public readonly string _filename;
    public TextConfigurationSource(string filename) {
        _filename = filename;
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder) {
        string filePath = builder.GetFileProvider().GetFileInfo(_filename).PhysicalPath!;
        return new TextConfigurationProvider(filePath);
    }
}
