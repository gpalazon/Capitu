using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Capitu.Infra
{
    public static class SystemWebExtensions
    {
        public static string ToJson(this object obj)
        {
            var serializer = new JsonSerializer
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var stringWriter = new StringWriter();
            var jsonWriter = new Newtonsoft.Json.JsonTextWriter(stringWriter);
            serializer.Serialize(jsonWriter, obj);


            return stringWriter.ToString();
        }

        public static T FromJson<T>(this object obj)
        {
            return JsonConvert.DeserializeObject<T>(obj as string);
        }
    }
}
