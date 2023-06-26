using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueslime : MonoBehaviour {

	private Rigidbody2D rb2d; 
	public float jumpHeight;
	public SpriteRenderer spriterenderer;
	public Sprite upSprite;
	public Sprite downSprite;

	// Use this for initialization
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();
		spriterenderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//check is he is jumping or falling
		Debug.Log (this.rb2d.velocity.y);
		if (this.rb2d.velocity.y > 0.1f) {
			spriterenderer.sprite = upSprite;
		} else {
			spriterenderer.sprite = downSprite;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
		Jump();
		}
	}


	void Jump() {
		rb2d.AddForce (Vector2.up * jumpHeight);
	}

}
