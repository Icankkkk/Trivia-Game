using System.Collections.Generic;
using UnityEngine;

namespace Trivia.Global.Database
{
    public class Database : MonoBehaviour
    {
        private const string _prefSkey = "packCount";
        public static Database databaseInstance;
        
        [SerializeField] private List<QuizStruct> _quizList;

        [SerializeField] 
        private int _linesQuest;

        public string _currentPack;

        public int _currentQuestion;

        public List<PackDataStruct> packList;

        private void Awake()
        {
            if (databaseInstance == null)
            {
                databaseInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            SetPackCount();
        }

        private void SetPackCount()
        {
            PlayerPrefs.SetInt(_prefSkey, packList.Count);
        }

        public void SetPack(string packName)
        {
            _currentPack = packName;
        }

        private void AddQuestAnswer(int number, string packID, Sprite image, string question, string A, string B, string C, string D, string hint, int correct)
        {
            _quizList[number].Image = Resources.Load<Sprite>(packID + "/" + (number + 1).ToString());
            _quizList[number].Question = question;
            _quizList[number].Choice[0] = A;
            _quizList[number].Choice[1] = B;
            _quizList[number].Choice[2] = C;
            _quizList[number].Choice[3] = D;
            _quizList[number].Hint = hint;
            _quizList[number].Answer = correct;
        }

        public void LoadQuiz(string pack)
        {
            var textFile = Resources.Load<TextAsset>(pack + "/" + pack);
            List<string> wordList = new List<string>(textFile.text.Split('\n'));

            int lineQuiz = 0;

            for (int i = 0; i < wordList.Count / _linesQuest; i++)
            {
                int number = int.Parse(wordList[lineQuiz]);
                Sprite image = Resources.Load<Sprite>(pack + "/" + number);

                string question = wordList[lineQuiz + 1];
                string A = wordList[lineQuiz + 2];
                string B = wordList[lineQuiz + 3];
                string C = wordList[lineQuiz + 4];
                string D = wordList[lineQuiz + 5];

                int correct = int.Parse(wordList[lineQuiz + 6]);

                string hint = wordList[lineQuiz + 2 + (correct - 1)];

                lineQuiz += 7;
                AddQuestAnswer(number - 1, pack, image, question, A, B, C, D, hint, correct);
            }
        }
    }
}

