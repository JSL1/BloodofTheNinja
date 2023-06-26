using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerball : MonoBehaviour {

	GameObject Player;
	private Animator anim;
	private Rigidbody2D rb2d;
	private bool Collectible = false;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("SHL");;
		anim = this.gameObject.GetComponent<Animator>();
		rb2d = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Collectible) {
			rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
			this.gameObject.GetComponent<Collider2D>().isTrigger = false;
		}
	}

	void OnTriggerEnter2D (Collider2D trig)
	{
		if (trig.tag == "Attack") {
			Debug.Log("ball attacked");
			anim.SetBool("Collectible", true);
			Collectible = true;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (Collectible) {
			if (col.gameObject.tag == "Player") {
				Player.GetComponent<Score>().wammo += 5f;
				Destroy (this.gameObject);
			}
		}
	}
}
