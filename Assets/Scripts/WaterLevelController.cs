using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelController : MonoBehaviour {

    private Vector2 startPosition;
    public Vector2 endPosition;
    private float timeToReachTarget=20f;
    private float t=0f;

    void Start()
    {
        startPosition=this.transform.position;
    }
    void Update()
    {
       t+=Time.deltaTime/timeToReachTarget;
       transform.position=Vector3.Lerp(startPosition,endPosition,t);
         //water starts from bottom and fills till it reaches the top by factor t
    }
}
