using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DDOL : MonoBehaviour {

	public static DDOL instance = null;

	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (this.gameObject);
		}
	}
		// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
