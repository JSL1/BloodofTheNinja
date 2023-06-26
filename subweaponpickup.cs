using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subweaponpickup : MonoBehaviour {

	public GameObject Player;
	private Animator anim;
	private Rigidbody2D rb2d;
	private bool collectible = false;
	public int subwebID = 1;


	//SHURIKEN

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
		anim = this.gameObject.GetComponent<Animator>();
		rb2d = this.gameObject.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		if (collectible) {
			anim.SetInteger("swID", subwebID);
			rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
			this.gameObject.GetComponent<Collider2D>().isTrigger = false;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Attack") {
			anim.SetBool("Collectible", true);
			collectible = true;
			}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (collectible) {
			if (col.gameObject.tag == "Player") {
				Player.GetComponent<PlayerController>().activesw = subwebID;
				Destroy (this.gameObject);
			}
		}
	}
}

