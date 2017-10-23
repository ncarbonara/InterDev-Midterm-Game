﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to cause a bunch of "Thought objects" for the player to collect
//to appear when the player passes through the trigger and have become "inspired"
public class ALTThoughtPulseBehavior : MonoBehaviour
{
	//A prefab for the Thought object
	public GameObject thoughtPrefab;

	public GameObject thought1;
	public GameObject thought2;
	public GameObject thought3;
	public GameObject thought4;
	public GameObject thought5;

	//The collider of the player, which this trigger script reacts to
	public Collider playerCollider;

	//The number of thoughts the trigger will spawn
	public int numberOfThoughts;

	//The position of the trigger
	Vector3 triggerPosition;

	//The UI text that lets the player know they've been "inspired,"
	//and that Thought objects will now start appearing
	public GameObject inspirationAlertText;

	// Use this for initialization
	void Start ()
	{
		triggerPosition = this.GetComponent<Transform> ().position;

		//Spawns all the thought objects that this collider will generate in advance,
		//so as to reduce lag that could occur mid-game
		thought1 = (GameObject)	Instantiate (thoughtPrefab, new Vector3 (triggerPosition.x + Random.Range (-2, 2), 
			triggerPosition.y + Random.Range (-2, 2), 
			triggerPosition.z + Random.Range (-2, 2)), Quaternion.identity);

		thought2 = (GameObject)	Instantiate (thoughtPrefab, new Vector3 (triggerPosition.x + Random.Range (-2, 2), 
			triggerPosition.y + Random.Range (-2, 2), 
			triggerPosition.z + Random.Range (-2, 2)), Quaternion.identity);

		thought3 = (GameObject)	Instantiate (thoughtPrefab, new Vector3 (triggerPosition.x + Random.Range (-2, 2), 
			triggerPosition.y + Random.Range (-2, 2), 
			triggerPosition.z + Random.Range (-2, 2)), Quaternion.identity);

		thought4 = (GameObject)	Instantiate (thoughtPrefab, new Vector3 (triggerPosition.x + Random.Range (-2, 2), 
			triggerPosition.y + Random.Range (-2, 2), 
			triggerPosition.z + Random.Range (-2, 2)), Quaternion.identity);

		thought5 = (GameObject)	Instantiate (thoughtPrefab, new Vector3 (triggerPosition.x + Random.Range (-2, 2), 
			triggerPosition.y + Random.Range (-2, 2), 
			triggerPosition.z + Random.Range (-2, 2)), Quaternion.identity);
	}

	//Checks for collisions with the trigger
	void OnTriggerEnter (Collider col)
	{

		//Only activates if the player has entered the collider
		if (col.gameObject.name == playerCollider.gameObject.name) {
			
			//Causes the inspiration altert text to appear onscreen
			inspirationAlertText.SetActive (true);

			//Awakens all of the thought objects (which are asleep by default)
			thought1.SetActive(true);
			thought2.SetActive(true);
			thought3.SetActive(true);
			thought4.SetActive(true);
			thought5.SetActive(true);

			//Destroys the trigger once it has been used, so that it can't be used again
			this.gameObject.SetActive (false);
		}
	}
}
