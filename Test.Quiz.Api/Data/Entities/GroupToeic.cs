using Test.Quiz.Api.Data.Entities.Interface;

namespace Test.Quiz.Api.Data.Entities
{
    public class GroupToeic: EntityBase
    {
        public int Id { get; set; }

        public int PartToeicId { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? Paragraph { get; set; }

        public string? Audio { get; set; }



        public virtual List<GroupToeicQuestion> GroupToeicQuestions { get; set; }

        public virtual PartToeic PartToeics { get; set; }



    }
}
