using UnityEngine;

public class MapsInOrder : MonoBehaviour
{
    [SerializeField] CenarioSO[] maps;
    [SerializeField] int currentMapIndex;
    [SerializeField] int currentTurn;

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
    }
}
