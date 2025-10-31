using System.IO;
using UnityEngine;
using TMPro;
[System.Serializable]
public class PlayerData
{
    public int ballsQuantity;
    public int ballDamage;

    public bool unlockedExponentialGrowth;
    public int damageToIncrease;

    public int eachXRounds;
    public int currentMoney;
}
public class PlayerStats : MonoBehaviour
{
    public int ballsQuantity;
    public int ballDamage;
    public int totalBallDamage;

    public bool unlockedExponentialGrowth;
    public int damageToIncrease;
    public int eachXRounds;
    [SerializeField] TextMeshProUGUI coinText;

    [Header("Save")]
    [SerializeField] string path = "/PlayerData.json";
    public int currentMoney { get; private set; }
    public static PlayerStats instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        path = Application.persistentDataPath + path;
    }
    private void Start()
    {
        Load();
        AddMoneyOnGameEnd.instance.UpdateMoney(currentMoney);
    }
    public void OnStartGame() //ta sendo ativado pelo script de morte, porque ele re-aplica em todo inicio de jogo (ja que esse aqui é dontdestroy) ou seja, tem dependencia
    {
        RecieveBalls.instance.onPlayerTurnEnd += () => totalBallDamage = CalculateBallDamage();

        DispararBolas shootBalls = DispararBolas.instance;
        print(shootBalls.quantidadeBolasMax + " " + ballsQuantity + " Somando bolas");
        shootBalls.quantidadeBolasMax = shootBalls.quantidadeBolasMax + ballsQuantity;
        shootBalls.CreateBallPool();
    } 
    public void AddMoney(int amount)
    {
        currentMoney = Mathf.Max(0, currentMoney + amount);
        AddMoneyOnGameEnd.instance.UpdateMoney(currentMoney);
    }
    public int CalculateBallDamage()
    {
        print("calculando...");
        if (unlockedExponentialGrowth)
        {
            int damageToSum = Mathf.FloorToInt(GameManager.instance.howManyRoudsPassed / eachXRounds);
            return ballDamage + damageToSum;
        }
        else
            return ballDamage;
    }
    [ContextMenu("Add Money")]
    void Add()
    {
        currentMoney += 10;
        AddMoneyOnGameEnd.instance.UpdateMoney(currentMoney);
        print(currentMoney);
    }
    #region Save and Load
    public void Save()
    {
        PlayerData data = new PlayerData();
        data.ballsQuantity = ballsQuantity;
        data.ballDamage = ballDamage;
        data.unlockedExponentialGrowth = unlockedExponentialGrowth;
        data.damageToIncrease = damageToIncrease;
        data.eachXRounds = eachXRounds;
        data.currentMoney = currentMoney;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
    public void Load()
    {
        if (File.Exists(path))
        {
            PlayerData data = JsonUtility.FromJson<PlayerData>(File.ReadAllText(path));
            ballsQuantity = data.ballsQuantity;
            ballDamage = data.ballDamage;
            unlockedExponentialGrowth = data.unlockedExponentialGrowth;
            damageToIncrease = data.damageToIncrease;
            eachXRounds = data.eachXRounds;
            currentMoney = data.currentMoney;
        }
    }
    #endregion
}
