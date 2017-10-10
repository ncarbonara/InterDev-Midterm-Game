using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks to see if all the Thought Pulse Triggers have been used,
//and displays game over text if so
public class GameOverChecker : MonoBehaviour {

	//All the triggers that release Inspiration Thoughts
	public GameObject thoughtPulseTrigger0;
	public GameObject thoughtPulseTrigger1;
	public GameObject thoughtPulseTrigger2;
	public GameObject thoughtPulseTrigger3;
	public GameObject thoughtPulseTrigger4;
	public GameObject thoughtPulseTrigger5;

	//All the Normal Thoughts in the game (the ones not released by triggers)
	public GameObject normalThought0;
	public GameObject normalThought1;
	public GameObject normalThought2;
	public GameObject normalThought3;
	public GameObject normalThought4;
	public GameObject normalThought5;
	public GameObject normalThought6;
	public GameObject normalThought7;
	public GameObject normalThought8;
	public GameObject normalThought9;
	public GameObject normalThought10;

	//The text when all triggers have been set off and all thoughts have been discovered
	public GameObject gameOverText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//First, the triggers are checked:
		//All Thought Pulse Triggers set themselves inactive after the player
		//has stepped through them. Therefore, if all are inactive, the player has stepped
		//through them all
		if (thoughtPulseTrigger0.activeSelf == false
		    && thoughtPulseTrigger1.activeSelf == false
		    && thoughtPulseTrigger2.activeSelf == false
		    && thoughtPulseTrigger3.activeSelf == false
		    && thoughtPulseTrigger4.activeSelf == false
			&& thoughtPulseTrigger5.activeSelf == false) {

			//Next, the Normal Thought objects. If all have been collected,
			//they will not exist
			if (normalThought0.activeSelf == false
				&& normalThought1.activeSelf == false
				&& normalThought2.activeSelf == false
				&& normalThought3.activeSelf == false
				&& normalThought4.activeSelf == false
				&& normalThought5.activeSelf == false
				&& normalThought6.activeSelf == false
				&& normalThought7.activeSelf == false
				&& normalThought8.activeSelf == false
				&& normalThought9.activeSelf == false
				&& normalThought10.activeSelf == false) {

			//Displays the game over text
			gameOverText.SetActive (true);
		}
		}
	}
}
