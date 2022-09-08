using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Trivia.Global.Database;

namespace Trivia.Scene.Level.LevelScene
{
    public class LevelScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TextMeshProUGUI _labelText;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoSelectPack);
        }

        private void Start()
        {
            SetLabelText();
        }

        private void GoSelectPack()
        {     
            SceneManager.LoadScene("Pack");
        }

        private void SetLabelText()
        {
            Database database = FindObjectOfType<Database>();
            string levelName = database._currentPack;
            _labelText.text = "Level " + levelName;
        }
    }

}
