using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExponentialGrowth : ShopItem
{
    [Header("Exponential Growth")]
    [SerializeField] int amountToAdd;
    [SerializeField] int eachXRounds = 4;

    PlayerStats playerStats;
    protected override void Start()
    {
        base.Start();
        playerStats = PlayerStats.instance;
    }
    protected override void Buy()
    {
        base.Buy();
    }
    protected override void DoAction()
    {
        amountOfTimesBought += 1;
        if (!playerStats.unlockedExponentialGrowth)
        {
            playerStats.unlockedExponentialGrowth = true;
            playerStats.damageToIncrease += amountToAdd;
            playerStats.eachXRounds = eachXRounds;
            components.descriptionText.text = $"Recebe <color=red> { playerStats.damageToIncrease } </color> de dano a cada <color=green> { eachXRounds }</color> rodadas";
            return;
        }
        playerStats.eachXRounds -= 1;
        components.descriptionText.text = $"Recebe <color=red> { playerStats.damageToIncrease } </color> de dano a cada <color=green> { eachXRounds }</color> rodadas";
    }
    public override void UpdateCostText()
    {
        base.UpdateCostText();
    }
    public override SaveUpgrades Save()
    {
        Stat amountToAdd = new Stat();
        amountToAdd.key = nameof(amountToAdd); //pega literalmente o nome da variavel
        amountToAdd.value = this.amountToAdd;

        Stat eachX = new Stat();
        eachX.key = nameof(eachXRounds);
        eachX.value = eachXRounds;

        SaveUpgrades saveUpgrade = base.Save();

        saveUpgrade.stats.Add(amountToAdd);
        saveUpgrade.stats.Add(eachX);
        return saveUpgrade;
    }
    public override void Load(SaveUpgrades saveUpgrade)
    {
        base.Load(saveUpgrade);
        for (int i = 0; i < saveUpgrade.stats.Count; i++)
        {
            if(saveUpgrade.stats[i].key == nameof(amountToAdd)) //se tiver o mesmo nome
            {
                amountToAdd = saveUpgrade.stats[i].value; //pega o valor guardado (dictionary)
            }
            else if (saveUpgrade.stats[i].key == nameof(eachXRounds))
            {
                eachXRounds = saveUpgrade.stats[i].value;
            }
        }
    }
    protected override void AfterLoad()
    {
        base.AfterLoad(); //base ja aplica os valores de custo
        if (playerStats.unlockedExponentialGrowth)
        {
            components.descriptionText.text = $"Recebe <color=red> {playerStats.damageToIncrease} </color> de dano a cada <color=green> {eachXRounds}</color> rodadas";
        }
    }
}
