using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet_SS : MonoBehaviour {

	public float speed = 3f;
	private Rigidbody2D rb2d;
	public bool isKillable;
	public string direction;

	// Use this for initialization
	void Start ()
	{
		rb2d = this.GetComponent<Rigidbody2D> ();
		if (direction == "left") {
			rb2d.velocity = new Vector2 ((speed * -1), 0);
		} else if (direction == "down") {
			rb2d.velocity = new Vector2 (0, (speed * -1));
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnCollisionEnter2D (Collision2D col)
	{
		if ((col.gameObject.tag != "Enemy") && (col.gameObject.tag != "Bullet")) {
			Destroy (this.gameObject);
		}
	}

	private void OnTriggerEnter2D (Collider2D trig)
	{
		if (isKillable) {
			if (trig.gameObject.tag == "Attack") {
				Destroy (this.gameObject);
			}
		}
	}
}
