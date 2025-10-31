using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;
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
    }
    void Start()
    {
        path = Application.persistentDataPath + jsonName;
        shop.SetActive(false);
        activateButton.onClick.AddListener(() => SetActive(true));
        deactivateButton.onClick.AddListener(() => SetActive(false));
        Save();
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

    }
}
