using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Trivia.Global.Database;
using UnityEngine.SceneManagement;

namespace Trivia.Scene.Level.LevelData
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private GameObject _levelButtonPrefabs;
        [SerializeField] private Transform _levelButtonContainer;
        [SerializeField] private List<Button> _levelButtonList;

        private void Start()
        {
            CreateLevel();
        }

        private void CreateLevel()
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject levelButton = Instantiate(_levelButtonPrefabs, new Vector3(0, 0, 0), Quaternion.identity, _levelButtonContainer);
                TextMeshProUGUI buttonText = levelButton.GetComponent<TextMeshProUGUI>();

                Database database = FindObjectOfType<Database>();

                int questionNumber = i + 1;

                string name = database._currentPack;
                string names = name.Substring(name.Length - 1);
                buttonText.text = names + " - " + (questionNumber);

                Button createLevelButton = levelButton.GetComponent<Button>();

                _levelButtonList.Add(createLevelButton);
                createLevelButton.onClick.RemoveAllListeners();
                createLevelButton.onClick.AddListener(delegate
                {
                    OnClickedLevel(questionNumber);
                });
            }
        }

        private void OnClickedLevel(int levels)
        {
            Database database = FindObjectOfType<Database>();
            database._currentQuestion = levels;

            GameplayScene();
        }

        private void GameplayScene()
        {    
            SceneManager.LoadScene("Gameplay");
        }
    }
}


