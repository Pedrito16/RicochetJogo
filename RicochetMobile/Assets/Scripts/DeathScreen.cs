using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class DeathScreen : MonoBehaviour
{
    public static bool isDead = false;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        deathPanel.SetActive(false);
        PlayerStats.instance.ApplyListeners();
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
