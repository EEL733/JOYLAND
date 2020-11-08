using Newtonsoft.Json;
using System.IO;

namespace JOYLAND.Util {
    public class JsonUtil<Type> {
        private static readonly JsonSerializer serializer = new JsonSerializer() {
            Formatting = Formatting.Indented
        };

        public static Type ReadJsonFile(string path) {
            using (JsonReader reader = new JsonTextReader(File.OpenText(@path))) {
                Type result = serializer.Deserialize<Type>(reader);
                return result;
            }
        }

        public static void WriteJsonFile(string path, Type target) {
            using (JsonWriter writer = new JsonTextWriter(File.CreateText(@path))) {
                serializer.Serialize(writer, target);
            }
        }
    }
}
