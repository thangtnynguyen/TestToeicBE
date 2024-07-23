using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace Test.Quiz.Api.Enums
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuestionTypeForm
    {
        [Description("QuestionReading")]
        Reading = 1,

        [Description("QuestionListening")]
        Listening = 2,

        [Description("QuestionUnderfine")]
        QuestionUnderfine = 0 
    }
}
