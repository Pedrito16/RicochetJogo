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
        components.descriptionText.text = $"Receba <color=green>+1</color> bola (atualmente: {DispararBolas.instance.quantidadeBolasMax} + )";
    }
    public override void UpdateCostText()
    {
        base.UpdateCostText();
    }
    public override SaveUpgrades Save()
    {
        return base.Save();
    }
}
