using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
public class DeathController : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    public UnityEvent onDie;
    bool dieOnce;
    public static DeathController instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        deathPanel.SetActive(false);
        PlayerStats.instance.OnStartGame();
    }
    [ContextMenu("Perder agora")]
    public void Die()
    {
        if (dieOnce) return;
        dieOnce = true;
        GameManager gameManager = GameManager.instance;
        onDie?.Invoke();
        scoreText.text = "Rodadas sobrevividas: " + gameManager.howManyRoudsPassed.ToString();
        Time.timeScale = 0f;
        deathPanel.SetActive(true);
    }
    public void RestartGame()
    {
        
        deathPanel.SetActive(false);
        ScoreController.instance.Save();
        ShopController.instance.Save();  //no futuro, trocar esses saves para um delegate, pra organizar melhor
        PlayerStats.instance.Save();
        GameManager.instance.howManyRoudsPassed = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
