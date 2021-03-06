using MyBooking.Core.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyBooking.Core.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJSON(this object obj) => JsonConvert.SerializeObject(obj, JsonSettings.JsonSerializerSettings);

        public static T FromJSON<T>(this string obj, JsonSerializerSettings settings = null) => JsonConvert.DeserializeObject<T>(obj, settings: settings);

        public static JObject ToJObject(this string obj) => JObject.Parse(obj);

        public static JObject FromObjToJObject(this object obj) => JObject.FromObject(obj);
    }
}