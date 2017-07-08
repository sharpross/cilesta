namespace Cilesta.Utils.Json
{
    using Newtonsoft.Json;

    public class JsonHelper
    {
        public static T Deserialize<T>(string text)
        {
            var result = default(T);

            if (!string.IsNullOrEmpty(text))
            {
                result = JsonConvert.DeserializeObject<T>(text);
            }

            return result;
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string Serialize(object obj, Newtonsoft.Json.Formatting formatting)
        {
            return JsonConvert.SerializeObject(obj, formatting);
        }
    }
}
