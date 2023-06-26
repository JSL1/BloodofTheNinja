using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

public int scene;
public GameObject GOScreen;
public GameObject Player;

	void Start ()
	{
		GOScreen = GameObject.Find ("GameOverScreen");
		Player = GameObject.FindGameObjectWithTag("Player");
		//Player.GetComponent<PlayerController>().playerhealth = 10;
		/*if (GOScreen.activeInHierarchy) {
			GOScreen.SetActive(false);
		} */
	}

	public void loadlevel (string name)
	{
		Debug.Log ("Level load requested" + name);
		SceneManager.LoadScene(name);
	}

	public void reLoad ()
	{
		scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene);
	}

	public void Continue ()
	{
		Debug.Log("Continue requested");
		reLoad();
	}

	public void Win ()
	{
		scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene + 1);
	}

	public void QuitRequest ()
	{
		Debug.Log("quit requested");
		Application.Quit();
	}

	public void playerDies ()
	{
		reLoad();
	}
}
