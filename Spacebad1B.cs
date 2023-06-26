using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacebad1B : MonoBehaviour {

	public GameObject Bullet;
	public Transform BulletStart;
	private Animator anim;
	public float attackCd = 1f;
	private float attackTimer = 0f;
	private bool shooting;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (shooting) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				shooting = false;
			}
		}
		Shoot();
	}

	void Shoot ()
	{	
		if (!shooting) {
			GameObject b = Instantiate (Bullet) as GameObject;
			b.transform.position = BulletStart.transform.position;
			shooting = true;
			attackTimer = attackCd;
		}
	}

}
