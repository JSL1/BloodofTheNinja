using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	GameObject Player;
	public float score;
	public float wammo;
	public float lives;
	float health;
	Text scoretxt;
	Text wepntxt;
	Text livestxt;
	// Image Healthbar;


	// Use this for initialization
	void Start ()
	{
		scoretxt = GameObject.Find("Score").GetComponent<Text>();
		wepntxt = GameObject.Find("#").GetComponent<Text>();
		livestxt = GameObject.Find("Lives").GetComponent<Text>();
		Player = GameObject.FindGameObjectWithTag("Player");
		//Healthbar = GameObject.Find("Healthbar").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoretxt = GameObject.Find("Score").GetComponent<Text>();
		wepntxt = GameObject.Find("#").GetComponent<Text>();
		livestxt = GameObject.Find("Lives").GetComponent<Text>();
		//Healthbar = GameObject.Find("Healthbar").GetComponent<Image>();
		Player = GameObject.FindGameObjectWithTag("Player");
		//health = Player.GetComponent<PlayerController>().playerhealth;
		wammo = Mathf.Clamp (wammo, 0, 50); // Sets the max value of your weapon ammo to 50
		scoretxt.text = ("SCORE: " + score); 
		wepntxt.text = (wammo + " / 50");
		livestxt.text = ("" + lives);
		//Healthbar.fillAmount = (health * 0.1f);
	}
}
