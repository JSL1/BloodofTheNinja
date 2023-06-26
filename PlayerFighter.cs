using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour {

	Rigidbody2D rb2d;
	float horizontal;
	float vertical;
	public float moveSpeed;
	public GameObject bullet;	
	private float attackCd = 0.07f;
	private float attackTimer = 0f;
	public bool isFighter = true;
	public float playerhealth;
	private bool shooting = false;
	private Animator anim;
	public GameObject GOScreen;

	void Start ()
	{
  		rb2d = GetComponent<Rigidbody2D>(); 
  		anim = GetComponent<Animator>();
	}

	void Update ()
	{
		if (playerhealth > 0) {
			movePlayer ();
			if (Input.GetButton ("Jump")) {
				Shoot ();
			}
			if (shooting) {
				if (attackTimer > 0) {
					attackTimer -= Time.deltaTime;
				} else {
					shooting = false;
				}
			}
		} else { 
			anim.SetTrigger("dead");
			StartCoroutine (Die());
		}
	}

	void FixedUpdate () {

	}

	void movePlayer() { //fix this later to be more like PlayerController
		horizontal = Input.GetAxisRaw("Horizontal");
	   	vertical = Input.GetAxisRaw("Vertical");
		rb2d.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
	}

	void Shoot ()
	{	
		if (!shooting) {
			GameObject b = Instantiate (bullet) as GameObject;
			b.transform.position = this.gameObject.transform.position;
			shooting = true;
			attackTimer = attackCd;
		}
	}

	// COLLISION DETECTION
	void OnCollisionEnter2D (Collision2D Col)
	{
		if (Col.gameObject.tag == "Bullet") {
			playerhealth = (playerhealth - 2);
			anim.SetTrigger ("hit");
		}
	}

	IEnumerator Die ()
	{
		yield return new WaitForSeconds(1);
		Debug.Log("Death requested");
		GOScreen.SetActive(true);
	}

}

