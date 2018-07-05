using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

    private int curSceneIndex,startSceneIndex;
    private void Start()
    {
        startSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Awake()
    {
        int numScenePersists = FindObjectsOfType<ScenePersist>().Length;
        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (startSceneIndex != curSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
