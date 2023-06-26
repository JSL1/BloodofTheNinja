using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swUI : MonoBehaviour {

public GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Player.GetComponent<PlayerController>().activesw == 1) {
			this.gameObject.SetActive (true);
		}
	}
}
