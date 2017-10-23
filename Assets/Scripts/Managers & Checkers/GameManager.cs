using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;	//Let's this script talk to UI text

//This script keeps track of the score and the time remaining 
//while displaying both via onscreen text
public class GameManager : MonoBehaviour {

	//Sets up a Singleton, so that the script attached
	//to each Thought object will be able to 
	//influence the score
	public static GameManager Instance;

	//The score, which can be influenced by the script
	//on all thought objects due to the Singleton
	public int score;

	//Keeps track of how much time is remaining
	public float timer;

	//A public bool that other scripts can check to see if the game is over
	public bool timesUp;

	//The text that displays the score
	public GameObject scoreText;

	//The text that shows how much time is remaining
	public GameObject timerText;

	//The text that appears when time has run out
	public GameObject gameOverText;

	// Use this for initialization
	void Start () {
		
		//Sets the Instance Singleton equal to this script,
		//so that any reference to Instance in other scripts will refer
		//back to the ScoreManager script
		Instance = this;

		//The score starts out at zero
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//Reduces the timer, unless time has run out
		if (timer > 0f) {
			timer -= Time.deltaTime;
		}

		//Rounds the timer to an int that looks nicer onscreen
		int roundedTimer = Mathf.RoundToInt(timer);

		//Updates the score text, in case another script has changed the score
		scoreText.GetComponent<TextMesh> ().text = ("Score: " + score);

		//Updates the timer text
		timerText.GetComponent<TextMesh> ().text = ("Time: " + roundedTimer);

		//Displays the game over text when time has run out
		if (timer <= 0f) {
			gameOverText.SetActive (true);
			timesUp = true;
		}
	}
}
