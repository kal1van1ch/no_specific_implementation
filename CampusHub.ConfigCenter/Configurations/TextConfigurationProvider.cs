namespace CampusHub.ConfigCenter.Configurations;


public class TextConfigurationProvider : ConfigurationProvider {
    private readonly string _filepath;

    public TextConfigurationProvider(string filepath) {
        _filepath = filepath;
    }

    public override void Load() {
        var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        using (StreamReader textReader = new StreamReader(_filepath)) {
            string? line;

            while ((line = textReader.ReadLine()) != null) {

                var elem = line.Split(":", 2);
                string key = elem[0].Trim();
                string? value = elem.Length > 1 ? elem[1].Trim() : "no value with this key";

                data.Add(key, value);
            }
        }

        Data = data!;
    }
}