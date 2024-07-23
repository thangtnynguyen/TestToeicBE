using Test.Quiz.Api.Data.Entities;

namespace Test.Quiz.Api.Data.EntityFrameworkCore.Seeders
{
    public static class ToeicScoreSeeder
    {
        public static List<ToeicScore> Data()
        {
            var toeicScores = new List<ToeicScore>();

            // Thêm điểm Reading, type = 1
            int[] readingScores = {
                5, 5, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90,
                95, 100, 105, 110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190,
                195, 200, 205, 210, 215, 220, 225, 230, 235, 240, 245, 250, 255, 260, 265, 270, 275, 280, 285, 290,
                295, 300, 305, 310, 315, 320, 325, 330, 335, 340, 345, 350, 355, 360, 365, 370, 375, 380, 385, 390,
                395, 400, 405, 410, 415, 420, 425, 430, 435, 440, 445, 450, 455, 460, 465, 470, 475, 480, 485, 490, 495
            };

            for (int i = 0; i <= 100; i++)
            {
                toeicScores.Add(new ToeicScore { Id = i + 1, NumberOfCorrect = i, Score = readingScores[i], Type = 1 });
            }

            // Thêm điểm Listening, type = 2
            int[] listeningScores = {
                5, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105,
                110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195, 200, 205,
                210, 215, 220, 225, 230, 235, 240, 245, 250, 255, 260, 265, 270, 275, 280, 285, 290, 295, 300, 305,
                310, 315, 320, 325, 330, 335, 340, 345, 350, 355, 360, 365, 370, 375, 380, 385, 390, 395, 400, 405,
                410, 415, 420, 425, 430, 435, 440, 445, 450, 455, 460, 465, 470, 475, 480, 485, 490, 495, 495, 495, 495
            };

            for (int i = 0; i <= 100; i++)
            {
                toeicScores.Add(new ToeicScore { Id = i + 102, NumberOfCorrect = i, Score = listeningScores[i], Type = 2 });
            }

            return toeicScores;
        }
    }
}
