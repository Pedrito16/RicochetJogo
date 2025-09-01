using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Scenario", menuName = "Scriptable Objects/Cenario")]
public class CenarioSO : ScriptableObject
{
    public Sprite[] sideDecorationsSprites = new Sprite[12];

    public Sprite sideWalls;

    public Sprite groundSprite;

    public Sprite barrierSprite;

    public Sprite topSprite;

    [Header("Configurações cenario")]
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
}
