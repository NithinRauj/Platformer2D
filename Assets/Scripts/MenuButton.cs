using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

    public void LoadMenu()
    {
       // ScenePersist[] scenePersistObjs=Find
        SceneManager.LoadScene(0);
    }
}
