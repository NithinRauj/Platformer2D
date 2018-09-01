using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

  [SerializeField] AudioClip heartSFX;
  private void OnTriggerEnter2D(Collider2D collider)
  {
    if(collider.GetComponent<Player>()){
    FindObjectOfType<GameSession>().LivesUpdate(1);
    AudioSource.PlayClipAtPoint(heartSFX,Camera.main.transform.position);
    Destroy(gameObject);
    }
  }	
}
