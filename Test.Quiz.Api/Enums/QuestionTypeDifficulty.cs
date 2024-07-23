using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace Test.Quiz.Api.Enums
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuestionTypeDifficulty
    {
        [Description("Easy")]
        Easy = 1,

        [Description("Average")]
        Average = 2,

        [Description("Difficult")]
        Difficult = 3
    }
}
