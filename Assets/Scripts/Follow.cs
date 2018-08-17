using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

public Transform target;
private float zOffset=-5f;

void Update()
{
    transform.position=new Vector3(target.transform.position.x,target.transform.position.y,zOffset);
}
	
}
