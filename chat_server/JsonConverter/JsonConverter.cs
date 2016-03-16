using Newtonsoft.Json;

namespace JsonConverterLib {

    public class JsonConverter<T> {

        public static string ObjectToJson(T f) {
            return JsonConvert.SerializeObject(f);
        }

        public static T JsonToObject(string json) {
            return JsonConvert.DeserializeObject<T>(json);
        }

    }

}