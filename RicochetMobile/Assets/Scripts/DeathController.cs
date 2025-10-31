using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
public class DeathController : MonoBehaviour
{
    public static bool isDead = false;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    public UnityEvent onDie;
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


    void Update()
    {
        if (isDead) Die();
    }
    [ContextMenu("Perder agora")]
    void Die()
    {
        GameManager gameManager = GameManager.instance;
        
        scoreText.text = "Rodadas sobrevividas: " + gameManager.howManyRoudsPassed.ToString();
        onDie?.Invoke();
        Time.timeScale = 0f;
        deathPanel.SetActive(true);
    }
    public void RestartGame()
    {
        
        deathPanel.SetActive(false);
        isDead = false;
        ScoreController.instance.Save();
        ShopController.instance.Save();  //no futuro, trocar esses saves para um delegate, pra organizar melhor
        PlayerStats.instance.Save();
        GameManager.instance.howManyRoudsPassed = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
