using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessions : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
   [SerializeField] int score = 0;
   
    void Awake()
    {
        int numberGameSessions = FindObjectsByType<GameSessions>(FindObjectsSortMode.None).Length;
        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            RestartGameSession();
            
        }
    }

    
    void RestartGameSession()
    {
        FindFirstObjectByType<ScenePersist>().ResetScenePersists();
        SceneManager.LoadScene(0);
      
        Destroy(gameObject);
    }

    void TakeLife()
    {
        playerLives --;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
        
    }

    public void AddtoScore(int pointstoAdd)
    {
        score+=pointstoAdd;
        scoreText.text = score.ToString();
    }

    

    

    
    void Update()
    {
        
    }
}
