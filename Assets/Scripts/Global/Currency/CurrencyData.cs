using UnityEngine;

namespace Trivia.Global.Currency
{
    public class CurrencyData : MonoBehaviour
    {
        [SerializeField] private int _gold;

        public int Gold => _gold;

        public void AddingGold(int amount)
        {
            _gold += amount;
        }

        public void SpendingGold(int amount)
        {
            _gold -= amount;
        }
    }

}
