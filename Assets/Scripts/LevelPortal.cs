using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour {

    [SerializeField] float levelLoadDelay;
    [SerializeField] float slowMoFactor=0.2f;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>())
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = slowMoFactor;
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        Time.timeScale = 1f;
        var curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneIndex + 1);
    }
}
