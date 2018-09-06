using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXSource : MonoBehaviour {
private AudioSource audioSrc;
private bool clipChanged=false;
[SerializeField] AudioClip gameOverSFX,backgroundSFX;
	
void Start()
{
    audioSrc=GetComponent<AudioSource>();
}
void Awake()
{
     int numOfAudioSFX=GameObject.FindGameObjectsWithTag("SFXSource").Length;
     if(numOfAudioSFX>1)
       {Destroy(gameObject);}
     else
       {DontDestroyOnLoad(gameObject);}
}
void Update(){
   
   if(SceneManager.GetActiveScene().buildIndex==4 && !clipChanged)
   {
      audioSrc.clip=gameOverSFX;
      audioSrc.loop=false;
      audioSrc.Play();
      clipChanged=true;
   }
   else if(SceneManager.GetActiveScene().buildIndex!=4 && clipChanged)
   {
    audioSrc.clip=backgroundSFX;
    clipChanged=false;
    audioSrc.loop=true;   
    audioSrc.Play();
   }
}
}
