using UnityEngine;

public class BiggerNumber : ShopItem
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Buy()
    {
        base.Buy();
    }
    protected override void DoAction()
    {
        amountOfTimesBought += 1;
        PlayerStats.instance.ballsQuantity += 1;
        UpdateDescription();
    }
    public override void UpdateCostText()
    {
        base.UpdateCostText();
    }
    public override void CheckIfCanBuyAgain()
    {
        base.CheckIfCanBuyAgain();

    }
    void UpdateDescription()
    {
        print("atualizando descrição");
        components.descriptionText.text = $"Receba <color=green>+1</color> bola (atualmente: <color=blue> {DispararBolas.instance.originalQuantidadeBolasMax}</color> + <color=green>{amountOfTimesBought}</color>)";
    }
    #region Save and Load
    public override SaveUpgrades Save()
    {
        return base.Save();
    }
    public override void Load(SaveUpgrades saveUpgrade)
    {
        base.Load(saveUpgrade);
    }
    protected override void AfterLoad()
    {
        UpdateDescription();
        CheckIfCanBuyAgain();
        base.AfterLoad();
    }
    #endregion
}
