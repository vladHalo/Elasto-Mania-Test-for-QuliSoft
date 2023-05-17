using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Text[] _moneyText;

    public void UpdateMoneyText(int indexMoney) => _moneyText.ForEach(x => x.text = $"{indexMoney}");
}