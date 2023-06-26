using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManEnemy : MonoBehaviour {

	public GameObject Bullet;
	public Transform BulletStart;
	private Animator anim;
	private float attackCd = 3f;
	private float attackTimer = 0f;
	private bool shooting;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
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
			this.gameObject.GetComponent<Animator> ().SetTrigger ("shoot");
			GameObject b = Instantiate (Bullet) as GameObject;
			b.transform.position = BulletStart.transform.position;
			this.gameObject.GetComponent<Animator> ().SetTrigger ("idle");
			shooting = true;
			attackTimer = attackCd;
		}
	}
}
