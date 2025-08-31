using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizGame
{
    public class QuestionAndAnswers
    {
        public int Id { get; set; }
        public string Questions { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
        public string AnswersString { get; set; }
        public int CorrectAnswer { get; set; }
        public int Level { get; set; } 
        public static string JsonStringToString(string jsonString)
        {
            List<string> answersList = JsonConvert.DeserializeObject<List<string>>(jsonString);
            return string.Join(", ", answersList); // Join list elements into a single string
        }
    }
}
