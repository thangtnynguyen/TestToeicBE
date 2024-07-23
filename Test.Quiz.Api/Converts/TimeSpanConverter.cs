using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Test.Quiz.Api.Converts
{
    public class TimeSpanConverter : JsonConverter<TimeSpan?>
    {
        public override TimeSpan? ReadJson(JsonReader reader, Type objectType, TimeSpan? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var jObject = JObject.Load(reader);
            if (jObject.TryGetValue("ticks", out var ticksToken) && ticksToken.Type == JTokenType.Integer)
            {
                long ticks = ticksToken.Value<long>();
                return TimeSpan.FromTicks(ticks);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, TimeSpan? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
