using UnityEngine;

[CreateAssetMenu(fileName = "Scenario", menuName = "Scriptable Objects/Cenario")]
public class CenarioSO : ScriptableObject
{
    public Sprite[] sideDecorationsSprites = new Sprite[12];

    public Sprite sideWalls;

    public Sprite groundSprite;

    public Sprite barrierSprite;

    public Sprite topSprite;
}
