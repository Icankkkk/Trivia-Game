using System.Collections.Generic;
using Trivia.Global.Database;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Trivia.Scene.Pack.PackData
{
    public class PackData : MonoBehaviour
    {
        [SerializeField] private GameObject _packButtonPrefabs;
        [SerializeField] private Transform _packButtonContainer;
        [SerializeField] private List<Button> _packButtonList;

        private string _prefsKey = "packCount";

        private void Start()
        {
            CreatePackButton();
        }

        private void CreatePackButton()
        {
            int packCount = PlayerPrefs.GetInt(_prefsKey);

            for (int i = 0; i < packCount; i++)
            {
                GameObject packButton = Instantiate(_packButtonPrefabs, new Vector3(0, 0, 0), Quaternion.identity, _packButtonContainer);
                Text buttonText = packButton.GetComponentInChildren<Text>();

                Database database = FindObjectOfType<Database>();

                string name = database.packList[i].packName;
                buttonText.text = name;

                int price = database.packList[i].packPrice;

                Button createdPackButton = packButton.GetComponent<Button>();
                _packButtonList.Add(createdPackButton);

                /* createdPackButton.onClick.AddListener(() 
                     => OnClickPack(name, price));*/

                createdPackButton.onClick.RemoveAllListeners();
                createdPackButton.onClick.AddListener(delegate
                {
                    OnClickPack(name, price);
                });
            }
        }

        private void OnClickPack(string name, int price)
        {
            Database database = FindObjectOfType<Database>();
            database.SetPack(name);

            Debug.Log(price.ToString());

            database.LoadQuiz(name);
            LevelScene();
        }

        private void LevelScene()
        {
            Debug.Log("Load to Level Scene!");
            SceneManager.LoadScene("Level");
        }
    }

}

