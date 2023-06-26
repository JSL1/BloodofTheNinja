using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorepopup : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = this.gameObject.GetComponent<Animator>();
		Destroy (this.gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
