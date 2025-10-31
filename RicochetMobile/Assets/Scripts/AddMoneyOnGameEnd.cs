using UnityEngine;

public class AddMoneyOnGameEnd : MonoBehaviour
{
    void Start()
    {
        DeathController.instance.onDie.AddListener(AddMoney);
    }
    void AddMoney()
    {
        int money = PlayerStats.instance.currentMoney;
        int rounds = GameManager.instance.howManyRoudsPassed;
        PlayerStats.instance.AddMoney(Mathf.CeilToInt(rounds / 1.75f));
    }
}
