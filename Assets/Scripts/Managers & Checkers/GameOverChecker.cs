using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks to see if all the Thought Pulse Triggers have been used,
//and displays game over text if so
public class GameOverChecker : MonoBehaviour {

	public GameObject thoughtPulseTrigger0;
	public GameObject thoughtPulseTrigger1;
	public GameObject thoughtPulseTrigger2;
	public GameObject thoughtPulseTrigger3;
	public GameObject thoughtPulseTrigger4;

	public GameObject gameOverText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//All Thought Pulse Triggers set themselves inactive after the player
		//has stepped through them. If all are inactive, the player has stepped
		//through them all
		if (thoughtPulseTrigger0.activeSelf == false
		    && thoughtPulseTrigger1.activeSelf == false
		    && thoughtPulseTrigger2.activeSelf == false
		    && thoughtPulseTrigger3.activeSelf == false
		    && thoughtPulseTrigger4.activeSelf == false) {

			//Displays the game over text
			gameOverText.SetActive (true);
		}
	}
}
