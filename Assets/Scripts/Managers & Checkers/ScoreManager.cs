using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;	//Let's this script talk to UI text

//This script keeps track of the score, and displays
//it via onscreen UI text
public class ScoreManager : MonoBehaviour {

	//Sets up a Singleton, so that the script attached
	//to each Thought object will be able to 
	//influence the score
	public static ScoreManager Instance;

	//The score, which can be influenced by the script
	//on all thought objects due to the Singleton
	public int score;

	//The UI text that displays the score
	public GameObject scoreText;

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

		//Updates the score text, in case another script has changed the score
		scoreText.GetComponent<TextMesh> ().text = ("Notebook\nScore: " + score);
	}
}
