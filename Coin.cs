using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	GameObject player;
	private Animator anim;
	private Rigidbody2D rb2d;
	public bool Collectible = true;
	public GameObject ScoreAnim;
	public float points;

	// Use this for initialization
	void Start () {
		player =GameObject.Find("SHL");
		anim = this.gameObject.GetComponent<Animator>();
		rb2d = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Collectible) {
			rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
			this.gameObject.GetComponent<Collider2D>().isTrigger = false;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (Collectible) {
			if (col.gameObject.tag == "Player") {
				player.GetComponent<Score> ().score = (player.GetComponent<Score> ().score + points);
				Instantiate (ScoreAnim, new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
				Destroy (this.gameObject);
			}
		}
	}
}
