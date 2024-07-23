using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Test.Quiz.Api.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PartToeicType
    {
        [Description("PartReding")]
        PartReding = 1,

        [Description("PartListening")]
        PartListening = 2,

        [Description("PartUnderfine")]
        PartUnderfine = 0
    }
}
