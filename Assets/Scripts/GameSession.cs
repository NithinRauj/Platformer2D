using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    private Player player;
    private int playerLives = 4;
    [SerializeField] int pickupScore = 0;
    private int finalScore=0;

    [SerializeField] Text livesText, scoreText;

    private int curSceneIndex;
    private bool textUIMoved=false;

    private void Start()
    {
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

   private void Update(){
       curSceneIndex = SceneManager.GetActiveScene().buildIndex;
       if(SceneManager.GetActiveScene().buildIndex==0)
         {Destroy(gameObject);}
     
       if(SceneManager.GetActiveScene().buildIndex==4)
       {
         GameObject textPlaceHolder=GameObject.FindGameObjectWithTag("ScoreTextHolder");
         textPlaceHolder.GetComponent<Text>().text=finalScore.ToString();
         Destroy(gameObject);
       }
   }
    public void ScoreUpdate(int scoreToAdd)
    {
        pickupScore += scoreToAdd;
        finalScore=pickupScore;
        scoreText.text = pickupScore.ToString();
    }
    public void LivesUpdate(int lifeToAdd)
    {
        playerLives+=1;
        Debug.Log("life increased by 1");
        livesText.text =playerLives.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        
        else
        {
            GoToGameOverScreen();
        }
    }
    void TakeLife()
    {
        playerLives -= 1;
        SceneManager.LoadScene(curSceneIndex);
        livesText.text = playerLives.ToString();
    }
    void GoToGameOverScreen()
    {
        SceneManager.LoadScene(4);
    }
}
