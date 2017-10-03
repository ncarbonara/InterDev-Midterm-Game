using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;	//Let's this script talk to UI text

//This script turns the "Inspiration!" alert text off after a few seconds
//so that it doesn't linger onscreen for the entire game
public class InspirationAlertTurnOff : MonoBehaviour {

	//Keeps track of how much time has passed since this object 
	//was set active
	float timer;

	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		//Ticks up the timer
		timer += Time.deltaTime;

		//Deactivates the "Inspiration!" text after time has passed
		if (timer > 5) {
			this.gameObject.SetActive (false);

			//Resets the timer
			timer = 0f;
		}
	}
}
