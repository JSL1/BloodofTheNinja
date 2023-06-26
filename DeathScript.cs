using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour {

	public Text goTxt;
	public GameObject player;
	public GameObject cmenu;
	private float lives;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("SHL");
		lives = player.GetComponent<Score>().lives;
		player.GetComponent<Score>().lives = lives - 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (lives > 0) {
			goTxt.text = "Ninja x " + player.GetComponent<Score>().lives;;
		} else {
			goTxt.text = "game over";
			cmenu.SetActive(false);
		}
	}
}
