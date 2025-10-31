using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class ItemComponents
{
    public Button buyButton;

    [Header("Texts")]
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI costText;
}
public abstract class ShopItem : MonoBehaviour
{
    //[SerializeField] int maxAmout; no futuro, botar um limite pra nao ser infinito

    [Header("Shop Item Info")]
    [SerializeField] int cost;
    public int amountOfTimesBought;
    public ItemComponents components;
    protected virtual void Start()
    {
        components.costText.text = cost.ToString();
        components.buyButton.onClick.AddListener(Buy);
    }
    protected virtual void Buy()
    {
        PlayerStats.instance.AddMoney(-cost);
        cost = Mathf.FloorToInt(cost + cost * 0.5f);
        components.costText.text = cost.ToString();

        DoAction();
        UpdateCostText();
    }
    protected abstract void DoAction();

    public virtual void UpdateCostText()
    {
        int money = PlayerStats.instance.currentMoney;
        if (money >= cost) components.costText.color = Color.green;
        else components.costText.color = Color.red;
    }
    #region Save and Load
    public virtual SaveUpgrades Save()
    {
        SaveUpgrades saveUpgrade = new SaveUpgrades();
        saveUpgrade.amountOfUpgradesBought = amountOfTimesBought;
        saveUpgrade.cost = cost;
        return saveUpgrade;
    }
    public virtual void Load(SaveUpgrades saveUpgrade)
    {
        print("loading");
        amountOfTimesBought = saveUpgrade.amountOfUpgradesBought;
        cost = saveUpgrade.cost;
    }
    protected virtual void AfterLoad()
    {
        components.costText.text = cost.ToString();
        UpdateCostText();
    }
    #endregion
}
