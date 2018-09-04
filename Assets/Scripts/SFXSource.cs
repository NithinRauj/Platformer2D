using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXSource : MonoBehaviour {
private AudioSource audioSrc;
private bool clipChanged=false;
[SerializeField] AudioClip gameOverSFX;
	
void Start()
{
    audioSrc=GetComponent<AudioSource>();
}
void Awake()
{
    DontDestroyOnLoad(gameObject);
}
void Update(){
    // int numOfAudioSFX=GameObject.FindGameObjectsWithTag("SFXSource").Length;
    // if(numOfAudioSFX>1)
    // {Destroy(gameObject);}
    // else
    // {DontDestroyOnLoad(gameObject);}
   if(SceneManager.GetActiveScene().buildIndex==4 && !clipChanged)
   {
      audioSrc.clip=gameOverSFX;
      audioSrc.loop=false;
      audioSrc.Play();
      clipChanged=true;
   }
   else if(SceneManager.GetActiveScene().buildIndex!=4)
   {
    clipChanged=false;
    audioSrc.loop=true;   
   }
}
}
