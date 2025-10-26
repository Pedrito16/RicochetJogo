using UnityEngine;

[CreateAssetMenu(fileName = "Inimigos", menuName = "Scriptable Objects/Inimigos")]
public class Inimigos : ScriptableObject
{
    public string Name;
    public int life;
    [HideInInspector] public int roundsToWin = 7;
    public RuntimeAnimatorController animatorController;
    public Sprite mainSprite;

    [Range(1, 5)]
    public int tilesDistance;

    [Space(1)]
    public Abilities ability;
}
