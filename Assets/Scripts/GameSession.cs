using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    private Player player;
    [SerializeField] int playerLives = 3;
    [SerializeField] int pickupScore = 0;

    [SerializeField] Text livesText, scoreText;

    private int curSceneIndex;

    private void Start()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        livesText.text = playerLives.ToString();
        scoreText.text = pickupScore.ToString();
    }

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    public void ScoreUpdate(int scoreToAdd)
    {
        pickupScore += scoreToAdd;
        scoreText.text = pickupScore.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        
        else
        {
            RestartGameSession();
        }
    }

    void TakeLife()
    {
        playerLives -= 1;
        SceneManager.LoadScene(curSceneIndex);
        livesText.text = playerLives.ToString();
    }
    void RestartGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
