using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour {

	public string Color;
	private Rigidbody2D rb2d;
	public GameObject bullet;
	public bool facingRight;

	// Use this for initialization
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();

		//facing direction
		if (facingRight) {
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		} else {
			transform.localScale = new Vector3 (transform.localScale.x * 1, transform.localScale.y, transform.localScale.z);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		//movement
		if (!facingRight) {
			transform.position = new Vector3 (transform.position.x - (3.2f * Time.deltaTime), transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 (transform.position.x - (-3.2f * Time.deltaTime), transform.position.y, transform.position.z);
		}

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		/*if (Color == "purple") {
			if (col.gameObject.tag == "Ground") {
				Jump ();
			}
		}*/
	}

	void Jump() {
		rb2d.AddForce (Vector2.up * 170f);
	}

	void Shoot() {
		GameObject b = Instantiate(bullet) as GameObject;
		b.transform.position = new Vector2(this.transform.position.x -1, this.transform.position.y);
	}

}
