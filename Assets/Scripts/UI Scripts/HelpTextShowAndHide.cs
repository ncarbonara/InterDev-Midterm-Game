using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script allows the player to show and hide the
//onscreen help text with the press of a button
public class HelpTextShowAndHide : MonoBehaviour {

	public GameObject helpText;
	public GameObject helpTextBackground;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Triggers if the player is pressing H
		if (Input.GetKeyUp (KeyCode.H)) {

			//Checks to see if the help text and background are
			//being shown or not, and changes this accordingly
			if (helpText.activeSelf == true
				&& helpTextBackground.activeSelf == true) {
				helpText.SetActive (false);
				helpTextBackground.SetActive (false);
			} else if (helpText.activeSelf == false
			    && helpTextBackground.activeSelf == false) {
				helpText.SetActive (true);
				helpTextBackground.SetActive (true);
			}
		}
	}
}
