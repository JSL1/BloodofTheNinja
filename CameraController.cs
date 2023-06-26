using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	//private Vector3 offset;
	public float startPosX;
	public float endPosX;
	// Use this for initialization
	void Start () {
		//offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position.x > startPosX) && (player.transform.position.x < endPosX)) {
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z); 
		}
	}
}
