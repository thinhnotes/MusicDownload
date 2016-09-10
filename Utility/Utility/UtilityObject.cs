using Newtonsoft.Json;

namespace Utility.Utility
{
    public static class UtilityObject
    {
        public static T DeserializeJsonAs<T>(this string obj)
        {
            //var javaScriptSerializer = new JavaScriptSerializer();
            //return javaScriptSerializer.Deserialize<T>(obj);
            return JsonConvert.DeserializeObject<T>(obj);
        }

        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}