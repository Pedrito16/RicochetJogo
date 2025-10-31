using UnityEngine;
using TMPro;
public class AddMoneyOnGameEnd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    public int moneyToAdd;
    public static AddMoneyOnGameEnd instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        DeathController.instance.onDie.AddListener(AddMoney);
    }
    void AddMoney()
    {
        int rounds = GameManager.instance.howManyRoudsPassed;
        moneyToAdd = Mathf.CeilToInt(rounds / 1.75f);
        print("resultado do calculo: " + moneyToAdd);
        PlayerStats.instance.AddMoney(moneyToAdd);
    }
    public void UpdateMoney(int money)
    {
        coinText.text = money.ToString();
    }
}
