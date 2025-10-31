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
        UpdateDescription();
    }
    public override void UpdateCostText()
    {
        base.UpdateCostText();
    }
    void UpdateDescription()
    {
        components.descriptionText.text = $"Receba <color=green>+1</color> bola (atualmente: <color=blue> {DispararBolas.instance.quantidadeBolasMax}</color> + <color=green>{amountOfTimesBought}</color>)";
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
        base.AfterLoad();
        UpdateDescription();
    }
    #endregion
}
