using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace Test.Quiz.Api.Enums
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuestionTypeKind
    {
        [Description("QuestionExam")]
        QuestionExam = 1,

        [Description("QuestionExamToeic")]
        QuestionExamToeic = 2,

        [Description("QuestionUnderfine")]
        QuestionUnderfine = 0 
    }
}
