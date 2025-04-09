using System.Collections;
using UnityEngine;
public enum GameState
{
    PlayerTurn,
    MovementTurn
}
public class GameManager : MonoBehaviour
{
    public static GameState state;
    [SerializeField] GameObject destroyProjectilesObject;
    void Start()
    {
        state = GameState.PlayerTurn;
    }

    
    void Update()
    {
        if (DispararBolas.instance.allBallsShot)
        {
            StartCoroutine(activateObjectAfterSeconds());
        }
        else
        {
            destroyProjectilesObject.SetActive(false);
        }
    }
    IEnumerator activateObjectAfterSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        destroyProjectilesObject.SetActive(true);
    }
}
