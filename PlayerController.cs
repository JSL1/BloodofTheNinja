using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private float moveX;
	private float moveY;
	private Rigidbody2D rb2d;
	public float playerSpeed;
	public float playerhealth;
	public int playerJumpPower;
	private Animator myAnim;
	public bool facingRight = true;
	private bool jumping;
	private bool hit;
	private bool ducking;
	private bool attacking = false;
	private float attackCd = 0.102f;
	private float attackTimer = 0f;
	private float shootTimer = 0f;
	private float shootCd = 0.07f;
	private bool shooting;
	private bool subwep = false;
	public int activesw = 0;
	public GameObject attacktrigger;
	public GameObject duckattacktrig;
	public GameObject shuriken;
	public GameObject shuriken2;
	public GameObject nBullet;
	public GameObject Gun;
	public GameObject subpos;
	private float jmpdir;
	private BoxCollider2D ninjaCollider;
	public GameObject GOScreen;
	GameObject SHL;

	// Use this for initialization
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();
		myAnim = this.GetComponent<Animator>();
		ninjaCollider = this.GetComponent<BoxCollider2D>();
		myAnim.SetBool("attack", false);
		playerhealth = 10;
		SHL = GameObject.Find("SHL");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerhealth > 0) {
			processIn ();
			if (!ducking && !hit) {
				movePlayer (); 
			}
		} else {
			Debug.Log ("health depleted.");
			StartCoroutine (Die ());
		}
	
		//check if the player is dead
		if (playerhealth == 0) {
			myAnim.SetBool ("dead", true);
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				myAnim.SetBool ("attack", false);
				attacktrigger.gameObject.SetActive (false);
				duckattacktrig.gameObject.SetActive (false);
			}
		}

		if (shooting) {
			if (shootTimer > 0) {
				shootTimer -= Time.deltaTime;
			} else {
				shooting = false;
			}
		}

		if (subwep) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				subwep = false;
				myAnim.SetBool ("subw", false);
			}
		}
		if (jumping) { // if the player is jumping, use the small hitbox
			ninjaCollider.size = new Vector2 (0.6f, 1f);
		}
		//Grab Score, ammo etc every frame. Very important
		SHL = GameObject.Find("SHL");
	}

	//player movement -most important
	void movePlayer ()
	{ 

		//shitty old movement that depends on rigidbody
		/*moveX = Input.GetAxis ("Horizontal");
		Debug.Log("moveX is " + moveX);
		rb2d.velocity = new Vector2 (moveX * playerSpeed, rb2d.velocity.y);
		myAnim.SetFloat ("speed", Mathf.Abs (moveX));*/

		// Horizontal movement and runing animation
		moveX = Input.GetAxis ("Horizontal");
		if (!jumping && !hit) {
				if (!attacking && !subwep) {
					if (moveX != 0) {
						myAnim.SetBool ("running", true);
						float dy = moveX * playerSpeed * Time.deltaTime;
						transform.position = new Vector2 (transform.position.x + dy, transform.position.y);	
					} else {
						myAnim.SetBool ("running", false);
					}
				}
			} else {
				if (moveX != 0) {
					float dy = (Mathf.Clamp ((moveX * 1.35f) + jmpdir, -1, 1)) * playerSpeed * Time.deltaTime; 
					// this above line is the the key to jumping like Ryu. Applies the force of moveX to the jump direction ONLY if its the opposite direction.
					//  I nailed this so hard. Fuck yeah I'm the best.
					transform.position = new Vector2 (transform.position.x + dy, transform.position.y);
				}
			}

			//Player Sprite's facing direction
			if (moveX < 0.0f && facingRight == true) {
				flipPlayer ();
			} else if (moveX > 0.0f && facingRight == false) {
				flipPlayer ();
			}
	}

	// Process Player Input
	void processIn ()
	{
		if (Input.GetButtonDown ("Jump")) {
			jump ();
			jumping = true;
		}
		// This is kinda sloppy. If the player is holding up or down, check if its down and duck, if neither is held, don't duck. 
		// I'll maybe optimize it later. maybe.
		// Nah probably not lmao
		moveY = Input.GetAxis ("Vertical"); // read if the player is holding up or down.
		if (moveY != 0) {
			duck ();
		} else {
			myAnim.SetBool ("ducking", false);
			ducking = false;
			ninjaCollider.size = new Vector2 (0.6f, 1.86f);
			ninjaCollider.offset = new Vector2 (0f, 0f);
		}
		if (Input.GetButtonDown ("Fire1")) {
			attack ();
		}
		if (Input.GetButtonDown ("Fire3")) { //For PRESSING fire3
			Throw ();
		}
		if ((Input.GetButton ("Fire3")) && (activesw == 2)) { // For HOLDING Fire3, very important distinction
			Gun.gameObject.SetActive (true);
			Throw ();
		} else {
			Gun.gameObject.SetActive (false);
		}
	}


	// Jumping etc
	void jump ()
	{
		if (!jumping && !hit) {
			rb2d.AddForce (Vector2.up * playerJumpPower);
			jmpdir = moveX;
			myAnim.SetBool ("jumping", true);		
		}
	}

	// Ducking, self-explanatory.
	void duck () {
		if (moveY < 0f && !jumping && !hit) {
			ducking = true;
			myAnim.SetBool ("running", false); // this line and the following line bruteforce the animation bugs. Not the best but it works
			//myAnim.SetBool ("jumping", false); //
			myAnim.SetBool ("ducking", true); // duck if the player is holding down. ez pz.
			ninjaCollider.size = new Vector2(0.6f, 1f);
			ninjaCollider.offset = new Vector2(0f, -0.44f);
		} else { 
			myAnim.SetBool ("ducking", false);
			ducking = false;
		}
	}

	//attacking
	void attack ()
	{
		if (!attacking && !hit) {
			myAnim.SetBool ("attack", true);
			attacking = true;
			if (!ducking) {
				attacktrigger.gameObject.SetActive (true);
			} else if (ducking) {
				duckattacktrig.gameObject.SetActive (true);
			}
			attackTimer = attackCd;
		} else {
			attacktrigger.gameObject.SetActive (false);
			duckattacktrig.gameObject.SetActive (false);
		}
	}

	//subweapons
	// 1 = shuriken, 2 = machinegun
	void Throw ()
	{
		if (activesw == 1) {
			if (SHL.GetComponent<Score> ().wammo > 0) {
				myAnim.SetBool ("subw", true);
				subwep = true;
				attackTimer = attackCd;
				SHL.GetComponent<Score> ().wammo -= 3f;
				if (facingRight) {
					Instantiate (shuriken, new Vector3 (subpos.gameObject.transform.position.x, subpos.gameObject.transform.position.y, transform.position.z), Quaternion.identity);
				} else if (!facingRight) {
					Instantiate (shuriken2, new Vector3 (subpos.gameObject.transform.position.x, subpos.gameObject.transform.position.y, transform.position.z), Quaternion.identity);
				}
			} 
		} else if (activesw == 2) {
			if (!shooting) {
				if (SHL.GetComponent<Score> ().wammo > 0) {
					//myAnim.SetBool ("subw", true);  (throwing animation)
					//subwep = true;
					SHL.GetComponent<Score> ().wammo -= 1f;
					Instantiate (nBullet, new Vector3 (subpos.gameObject.transform.position.x, subpos.gameObject.transform.position.y, transform.position.z), Quaternion.identity);
					shooting = true;
					shootTimer = shootCd;
				}
			}
		}
	}
	//************************************************************************
	// ***********************COLLISION DETECTION****************************
	//************************************************************************
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Ground") { // when the player lands a jump
			myAnim.SetBool ("jumping", false);
			hit = false;
			myAnim.SetBool ("hit", false);
			jumping = false;
			ninjaCollider.size = new Vector2 (0.6f, 1.86f);
		} else if (col.gameObject.tag == "Enemy") {
			float dmg = col.gameObject.GetComponent<EnemyHealth>().damage;
			playerhealth = (playerhealth - dmg);
			hit = true;
			myAnim.SetTrigger ("hit");
			rb2d.velocity = new Vector2 (0, 0); //reset the velocity so you can't superjump
			if (!facingRight) {
				rb2d.AddForce (new Vector2 (200, 300));
			} else {
				rb2d.AddForce (new Vector2 (-200, 300));
			}
			Debug.Log (playerhealth);
		} else if (col.gameObject.tag == "Bullet") {
			playerhealth = (playerhealth - 1);
			hit = true;
			myAnim.SetTrigger ("hit");
			rb2d.velocity = new Vector2 (0, 0); //reset the velocity so you can't superjump
			if (!facingRight) {
				rb2d.AddForce (new Vector2 (200, 300));
			} else {
				rb2d.AddForce (new Vector2 (-200, 300));
			}
			Debug.Log (playerhealth);
		}
	}


	void flipPlayer ()
	{
		if (!jumping && !attacking) {
			facingRight = !facingRight;
			Vector2 localScale = gameObject.transform.localScale;
			localScale.x *= -1;
			transform.localScale = localScale;
		}
	}

	//Player Death
	IEnumerator Die ()
	{
		yield return new WaitForSeconds(1);
		Debug.Log("Death requested");
		GOScreen.SetActive(true);
	}

}