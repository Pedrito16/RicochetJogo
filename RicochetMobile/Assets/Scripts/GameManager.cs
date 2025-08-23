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
    public static int howManyRoudsPassed;
    [SerializeField] GameObject destroyProjectilesObject;
    void Start()
    {
        state = GameState.PlayerTurn;
        //Time.timeScale = 0.2f;
    }


    void Update()
    {
        if (DispararBolas.instance.allBallsShot && state == GameState.PlayerTurn)
        {
            StartCoroutine(activateObjectAfterSeconds());
        }
        else if (!DispararBolas.instance.allBallsShot && state == GameState.PlayerTurn)
        {
            destroyProjectilesObject.SetActive(false);
        }
        
    }
    IEnumerator activateObjectAfterSeconds()
    {
        yield return new WaitForSeconds(0.25f);
        destroyProjectilesObject.SetActive(true);
    }
}
