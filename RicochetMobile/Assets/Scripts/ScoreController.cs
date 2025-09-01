using System.IO;
using UnityEngine;
using TMPro;
public class SaveScore
{
    public int highScore;
    public SaveScore(int highScore)
    {
        this.highScore = highScore;
    }
}
public class ScoreController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] private int highScore;
    [SerializeField] TextMeshProUGUI highScoreText;

    public static ScoreController instance;
    private void Awake()
    {
        if (instance == null)
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
        Load();
        RecieveBalls.instance.onPlayerTurnEnd += UpdateRoundsText;
    }
    void Update()
    {
        
    }
    void UpdateRoundsText()
    {
        score++;
        scoreText.text = "Rodadas: " + score.ToString();
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "Recorde: " + highScore.ToString();
        }
    }
    void Load()
    {
        string path = Application.persistentDataPath + "/Score.json";
        if (File.Exists(path))
        {
            SaveScore saveScore = JsonUtility.FromJson<SaveScore>(File.ReadAllText(path));
            highScore = saveScore.highScore;
            highScoreText.text = "Recorde: " + highScore.ToString();
        }
    }
    public void Save()
    {
        string path = Application.persistentDataPath + "/Score.json";
        print(path);

        SaveScore highScore = new SaveScore(this.highScore);
        File.WriteAllText(path, JsonUtility.ToJson(highScore));
    }
}
