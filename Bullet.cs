using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 25.0f;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2 (0, speed);
	}
	
	// Update is called once per frame
	void Update ()
	{

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
