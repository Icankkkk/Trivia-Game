using UnityEngine;

namespace Trivia.Global
{
    [System.Serializable]
    public class QuizStruct
    {
        public Sprite Image;
        public string PackID;
        public string Question;
        public string Hint;
        public string[] Choice;
        public int Answer;
    }
}


