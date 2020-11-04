using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace JOYLAND {
    class JsonUtil<Type> {
        private static JsonSerializerOptions options = new JsonSerializerOptions {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        public static Type ReadJsonFileAsync(string pathStr) {
            string path = Path.GetFullPath(pathStr);
            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Type>(jsonString, options);
        }

        public static void WriteJsonFile(string pathStr, Type target) {
            string path = Path.GetFullPath(pathStr);
            string jsonString = JsonSerializer.Serialize(target, options);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, jsonString);
        }
    }
}
