using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HBSW : MonoBehaviour {

	public GameObject sw1;
	public GameObject sw2;
	public GameObject Player;
	public GameObject Healthbar;
	public Image HealthbarI;
	float health;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Update the Subweapon icon
		if (Player.GetComponent<PlayerController> ().activesw == 0) {
			sw1.SetActive (false);
			sw2.SetActive (false);
		} else if (Player.gameObject.GetComponent<PlayerController> ().activesw == 1) {
			sw2.SetActive (false);
			sw1.SetActive (true);
		} else if (Player.gameObject.GetComponent<PlayerController> ().activesw == 2) {
			sw1.SetActive (false);
			sw2.SetActive (true);
		}
		//Update health bar
		health = Player.GetComponent<PlayerController>().playerhealth; 
		HealthbarI.fillAmount = (health * 0.1f);
	}
}
