using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	GameObject Player;
	public float damage;
	public float points;
	public float health = 1;
	public GameObject ScoreAnim;
	private Animator animator;
	private bool hit;
	private Rigidbody2D rb2d;
	public string EType;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("SHL");
		animator = this.gameObject.GetComponent<Animator>();
		rb2d = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter2D (Collider2D trig)
	{
		if (trig.tag == "Attack") {
			health = (health - trig.gameObject.GetComponent<Dmg>().damage);
			StartCoroutine(Flash());
			if (health == 0) {
				this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
				this.gameObject.GetComponent<Animator> ().SetTrigger ("dead");
				this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
				Debug.Log (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).length);
				Player.GetComponent<Score> ().score = (Player.GetComponent<Score> ().score + points);
				Instantiate (ScoreAnim, new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
				Destroy (gameObject, 0.4f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D Col)
	{
		if (Col.gameObject.tag == "BorderBottom") {
			Destroy(this.gameObject);
		}
	}

	IEnumerator Flash ()
	{
		this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		yield return new WaitForSeconds(.1f);
		this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

	}
	void Die ()
	{
		
	}
}
