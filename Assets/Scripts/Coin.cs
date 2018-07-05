using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField] AudioClip coinSfx;
    [SerializeField] int coinValue = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().ScoreUpdate(coinValue);
        AudioSource.PlayClipAtPoint(coinSfx, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
