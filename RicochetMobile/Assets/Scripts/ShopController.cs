using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;
using TMPro;
#region Classes puras de save
[Serializable]
public class Stat
{
    public string key;
    public int value;
}
[Serializable]
public class SaveUpgrades
{
    public int cost;
    public int amountOfUpgradesBought;
    public List<Stat> stats = new List<Stat>();
}
[Serializable]
public class SaveUpgradesWrapper
{
    public List<SaveUpgrades> saveUpgrades = new List<SaveUpgrades>();
}
#endregion
public class ShopController : MonoBehaviour
{
    [Header("Shop Activation")]
    [SerializeField] GameObject shop;
    [SerializeField] Button activateButton;
    [SerializeField] Button deactivateButton;

    [Header("Shop Config")]
    [SerializeField] ShopItem[] shopItems;
    [SerializeField] TextMeshProUGUI moneyText;

    [Header("Save Config")]
    [SerializeField] SaveUpgradesWrapper saveUpgrades;
    [SerializeField] string jsonName = "SavedUpgrades.json";
    [SerializeField] string path;

    public static ShopController instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        path = Application.persistentDataPath + jsonName;
    }
    void Start()
    {
        Load();
        shop.SetActive(false);
        activateButton.onClick.AddListener(() => SetActive(true));
        deactivateButton.onClick.AddListener(() => SetActive(false));
    }
    void SetActive(bool active)
    {
        shop.SetActive(active);
        if (!active) return;
        for(int i = 0; i < shopItems.Length; i++)
        {
            shopItems[i].UpdateCostText();
        }
    }
    public void Save()
    {
        
        for(int i = 0; i < shopItems.Length; i++)
        {
            saveUpgrades.saveUpgrades.Add(shopItems[i].Save());
        }
        string json = JsonUtility.ToJson(saveUpgrades, true);
        File.WriteAllText(path, json);
    }
    public void Load()
    {
        if (File.Exists(path))
        {
            SaveUpgradesWrapper saveUpgradesWrapper = JsonUtility.FromJson<SaveUpgradesWrapper>(File.ReadAllText(path));
            for (int i = 0; i < shopItems.Length; i++)
            {
                shopItems[i].Load(saveUpgradesWrapper.saveUpgrades[i]);
            }
        }
    }
}
