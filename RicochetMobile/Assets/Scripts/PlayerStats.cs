using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public int ballsQuantity;
    public int ballDamage;
    public int totalBallDamage;

    public bool unlockedExponentialGrowth;
    public int damageToIncrease;
    public int eachXRounds;

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
    }
    private void Start()
    {
        
    }
    public void ApplyListeners() //ta sendo ativado pelo script de morte, porque ele re-aplica em todo inicio de jogo (ja que esse aqui é dontdestroy) ou seja, tem dependencia
    {
        RecieveBalls.instance.onPlayerTurnEnd += () => totalBallDamage = CalculateBallDamage();
        RecieveBalls.instance.onPlayerTurnEnd += () => print("eu fui ativado mesmo assim");
    } 
    public void AddMoney(int amount)
    {
        currentMoney += amount;
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
    }
}
