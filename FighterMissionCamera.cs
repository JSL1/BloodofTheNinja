using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMissionCamera : MonoBehaviour {

	public float Step;
	public float startPosY;
	public float endPosY;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.y < endPosY) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + (2 * Time.deltaTime), transform.position.z);
		}
	}
}