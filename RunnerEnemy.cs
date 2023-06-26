using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (transform.position.x - 0.09f, transform.position.y, transform.position.z);
	}
}
