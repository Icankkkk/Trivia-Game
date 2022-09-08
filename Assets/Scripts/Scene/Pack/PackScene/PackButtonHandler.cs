using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Trivia.Scene.Pack.PackScene
{
    public class PackButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(OpenHome);
        }

        private void OpenHome()
        {
            Debug.Log("Load to Home Scene!");
            SceneManager.LoadScene("Home");
        }

    }

}
