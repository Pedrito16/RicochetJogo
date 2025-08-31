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
            ChangeScenario();
        }
    }
    void ChangeScenario()
    {
        currentMapIndex++;
        CenarioLoader loader = CenarioLoader.instance;
        if(currentMapIndex < maps.Length - 1)
        {
            loader.LoadCenario(maps[currentMapIndex]);

        }
        else if(currentMapIndex > maps.Length - 1)
        {
            currentMapIndex = 0;
            loader.LoadCenario(maps[currentMapIndex]);
        }
    }
}
