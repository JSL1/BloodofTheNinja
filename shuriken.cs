﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuriken : MonoBehaviour {

	public GameObject Player;
	private bool shtr;
	public float speed;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{	
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Ground") {
			Destroy (this.gameObject);
		}
	}

	void OnBecomeInvisible ()
	{
		Destroy (this.gameObject);
	}
}

