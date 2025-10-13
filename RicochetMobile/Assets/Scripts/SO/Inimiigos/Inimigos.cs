using UnityEngine;

[CreateAssetMenu(fileName = "Inimigos", menuName = "Scriptable Objects/Inimigos")]
public class Inimigos : ScriptableObject
{
    public string Name;
    public int life;
    [HideInInspector] public int roundsToWin = 7;

    [Range(1, 5)]
    public int tilesDistance;

    public Sprite normalSprite;
    public Sprite damagedSprite;
}
