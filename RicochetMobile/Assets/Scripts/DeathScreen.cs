using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class DeathScreen : MonoBehaviour
{
    public static bool isDead = false;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    Ball bolasGordas;
    void Start()
    {
        deathPanel.SetActive(false); 
    }

    
    void Update()
    {
        if (isDead) Die();
    }
    void Die()
    {
        scoreText.text = "Rodadas sobrevividas: " + GameManager.instance.howManyRoudsPassed.ToString();
        Time.timeScale = 0f;
        deathPanel.SetActive(true);
    }
    public void RestartGame()
    {
        deathPanel.SetActive(false);
        isDead = false;
        ScoreController.instance.Save();
        GameManager.instance.howManyRoudsPassed = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
