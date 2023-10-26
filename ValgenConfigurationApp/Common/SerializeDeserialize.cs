using Newtonsoft.Json;

namespace ValgenConfigurationApp.Common
{
    public class SerializeDeserialize
    {
        public static string SerializeObject(object model)
        {
            JsonConvert.SerializeObject(model, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return JsonConvert.SerializeObject(model);
        }
    }
}
