using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaBullet : MonoBehaviour {

	public float speed = 25.0f;
	private Rigidbody2D rb2d;
	public GameObject Player;

	// Use this for initialization
	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		rb2d = this.gameObject.GetComponent<Rigidbody2D> ();
		if (Player.gameObject.GetComponent<PlayerController> ().facingRight == true) {
			rb2d.velocity = new Vector2 (speed, 0);
		} else if (Player.gameObject.GetComponent<PlayerController> ().facingRight == false) {
			rb2d.velocity = new Vector2 ((speed * -1), 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Border") {
			Destroy (this.gameObject);
		} else if (other.gameObject.tag == "Enemy") {
			Destroy (this.gameObject);
		}
	}
}
