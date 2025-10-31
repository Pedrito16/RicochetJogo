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
    [SerializeField] int maximumAmountOfTimesCanBuy = 3;
    public ItemComponents components;
    protected virtual void Start()
    {
        components.costText.text = cost.ToString();
        components.buyButton.onClick.AddListener(Buy);
    }
    protected virtual void Buy()
    {
        if (!CanBuy() || amountOfTimesBought >= maximumAmountOfTimesCanBuy)
        {
            return;
        }
        PlayerStats.instance.AddMoney(-cost);
        cost = Mathf.FloorToInt(cost + cost * 0.5f);
        components.costText.text = cost.ToString();

        CheckIfCanBuyAgain();
        DoAction();
        UpdateCostText();
    }
    protected abstract void DoAction();

    public virtual void UpdateCostText()
    {
        if (CanBuy() || amountOfTimesBought >= maximumAmountOfTimesCanBuy) components.costText.color = Color.green;
        else components.costText.color = Color.red;
    }
    public virtual void CheckIfCanBuyAgain()
    {
        UpdateCostText();
        if (!CanBuy() || amountOfTimesBought >= maximumAmountOfTimesCanBuy)
        {
            components.buyButton.interactable = false;
        }
        else
        {
            components.buyButton.interactable = true;
        }
    }
     protected bool CanBuy()
    {
        int money = PlayerStats.instance.currentMoney;
        return money >= cost;
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
        AfterLoad();
    }
    protected virtual void AfterLoad()
    {
        components.costText.text = cost.ToString();
        UpdateCostText();
    }
    #endregion
}
