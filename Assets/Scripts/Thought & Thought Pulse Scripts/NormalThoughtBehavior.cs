﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;	//Allows this script to talk to UI text

//This script determines how Thought objects will move,
//and allows them to be collected
public class NormalThoughtBehavior : MonoBehaviour
{
	//The rigidbody of the Thought object
	Rigidbody rbody;

	//The collider of the Thought object
	public Collider collide;

	//The distance away from a thought object the player has to be
	//in order to collect it
	public float distanceToCollect;

	//These floats are used to calculate how long a Thought should
	//continue moving in the same random direction before changing
	//to a new random direction
	float timer;
	public float timeToChangeDirection;

	//This is the reticile GameObject, which changes color when the player is within
	//pickup range of a Thought object
	public GameObject reticle;

	// Use this for initialization
	void Start ()
	{
		rbody = this.GetComponent<Rigidbody> ();

		//Randomly selects a random velocity and direction for the Thought 
		//to start moving in
		rbody.velocity = new Vector3 (Random.Range (-1.5f, 1.5f), Random.Range (-1.5f, 1.5f), Random.Range (-1.5f, 1.5f));
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Generates a ray out from the camera
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		//Checks if the ray hit a Rogue Thought object
		if (Physics.Raycast (ray, out hit, distanceToCollect)
		    && hit.collider == collide) {

			//Changes the reticle color
			reticle.GetComponent<Text> ().color = Color.red;

			//Checks if the player is clicking to collect an object
			if (Input.GetKey (KeyCode.Mouse0)) {

				//Access the variable holding the score from the ScoreManager script 
				//via the ScoreManager Singleton "Instance," and adds to it
				//when a Thought has been collected
				GameManager.Instance.score++;

				//Deactivates the Normal Thought once it has been used, so that it can't be used again.
				//Unlike Inspiration Thoughts, Normal Thoughts aren't destroyed, because the script
				//GameOverChecker needs to access them again.
				this.gameObject.SetActive (false);

				//Returns the reticle to it's normal color
				reticle.GetComponent<Text> ().color = Color.black;
			}
		}
	
		//Removes the Thought from the scene when the game timer has run to zero,
		//as determined in the game manager
		if (GameManager.Instance.timesUp == true) {
			this.gameObject.SetActive (false);
		}
	}

	//Update called once every physics frame
	void FixedUpdate ()
	{

		//Every time the timer reaches a certain value, this if-statement is triggered
		if (timer <= timeToChangeDirection) {

			//Randomly selects a new velocity and direction for the Thought to move in
			rbody.velocity = new Vector3 (Random.Range (-1.5f, 1.5f), Random.Range (-1.5f, 1.5f), Random.Range (-1.5f, 1.5f));

			//Resets the timer
			timer = 0;
		}

		//Keeps the Thought from getting too close to the ground
		if (this.GetComponent<Transform> ().position.y < 1f) {

			//Gets the X and Z coordinates of the Thought, which will be put back into
			//it's position
			float xPos = this.GetComponent<Transform> ().position.x;
			float zPos = this.GetComponent<Transform> ().position.z;

			//Moves the thought object to where it should be
			this.GetComponent<Transform> ().position = new Vector3 (xPos, 1f, zPos);
		}
	}
}
