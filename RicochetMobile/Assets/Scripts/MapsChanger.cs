using UnityEngine;

public class MapsChanger : MonoBehaviour
{
    [SerializeField] CenarioSO[] maps;
    [SerializeField] int currentMapIndex;
    [SerializeField] int currentTurn;
    public delegate void OnMapChange(CenarioSO cenario);
    public OnMapChange OnMapSwitch;
    public static MapsChanger instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        RecieveBalls.instance.onPlayerTurnEnd += CountTurns;
    }
    void CountTurns()
    {
        currentTurn += 1;
        if(currentTurn % 3 == 0)
        {
            print("indo trocar de cenario");
            ChangeScenario();
        }
    }
    void ChangeScenario()
    {
        if (currentMapIndex + 1 >= maps.Length) currentMapIndex = 0;
        else currentMapIndex++;

        CenarioLoader loader = CenarioLoader.instance;
        loader.LoadCenario(maps[currentMapIndex]);
        OnMapSwitch?.Invoke(maps[currentMapIndex]);
    }
}
