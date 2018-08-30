using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {
  
    private int startSceneIndex;
    private static int previousSceneIndex=0;
    private void Start()
    {
        startSceneIndex = SceneManager.GetActiveScene().buildIndex;
        previousSceneIndex=SceneManager.GetActiveScene().buildIndex;
    }
    private void Awake()
    {
        int actualSceneIndex=SceneManager.GetActiveScene().buildIndex;
        if(actualSceneIndex==previousSceneIndex)
     {
        int numScenePersists = FindObjectsOfType<ScenePersist>().Length;
        if (numScenePersists > 1)
        {
            Debug.Log("coins from level "+startSceneIndex+" destroyed");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("coins from level "+startSceneIndex);
            DontDestroyOnLoad(gameObject);
        }
     }
     else
     {
         StartCoroutine(ExecuteSingleton());
     }
    }
     
    IEnumerator ExecuteSingleton()
    {
     yield return new WaitForSecondsRealtime(Time.deltaTime);
     int numScenePersists=GameObject.FindObjectsOfType<ScenePersist>().Length;
     if(numScenePersists>1)
     {Destroy(gameObject);}
     else
     {DontDestroyOnLoad(gameObject);}
    }
    private void Update()
    {
        CheckIfStillInSameScene();
    }
    void CheckIfStillInSameScene()
    {
      int actualSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (startSceneIndex != actualSceneIndex)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
