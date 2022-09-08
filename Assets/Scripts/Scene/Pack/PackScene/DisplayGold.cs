using UnityEngine;
using TMPro;

namespace Trivia.Scene.Pack.PackScene
{
    public class DisplayGold : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private int gold = 200;  // temp

        void Update()
        {
            // TODO: Get data from Currency 
            // _goldText.text = "Gold: " + gold.ToString(); // temp
        }
    }
}


