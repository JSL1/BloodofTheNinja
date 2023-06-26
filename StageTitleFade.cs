using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTitleFade : MonoBehaviour {

	private Rigidbody2D rb2d; 

	// Use this for initialization
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();
		StartCoroutine(Go());
	}

	IEnumerator Go() {
		yield return new WaitForSeconds(1);
		Drop();
		yield return new WaitForSeconds(5);
		Destroy(this.gameObject);
	}
	// Update is called once per frame
	void Update ()
	{

	}

	void Drop () {
		rb2d.gravityScale = -4;
	}
}
