using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    [SerializeField] int playerLives = 2;

    private int curSceneIndex;

    private void Start()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
    }
    void RestartGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
