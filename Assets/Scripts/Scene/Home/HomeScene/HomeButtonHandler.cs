using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Trivia.Scene.Home.HomeScene
{
    public class HomeButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            _startButton.onClick.RemoveAllListeners();
            _startButton.onClick.AddListener(StartPlay);
        }

        private void StartPlay()
        {
            Debug.Log("Load to Pack Scene!");
            SceneManager.LoadScene("Pack");
        }
    }
}


