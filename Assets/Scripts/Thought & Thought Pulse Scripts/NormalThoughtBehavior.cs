﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	// Use this for initialization
	void Start ()
	{
		rbody = this.GetComponent<Rigidbody> ();

		timer = 0f;

		//Randomly selects a random velocity and direction for the Thought 
		//to start moving in
		rbody.velocity = new Vector3 (Random.Range (-.5f, .5f), Random.Range (-.5f, .5f), Random.Range (-.5f, .5f));
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Checks if the player is clicking to collect an object
		if (Input.GetKey (KeyCode.Mouse0)) {
		
			//Generates a ray out from the camera
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			//Checks if the ray hit a Rogue Thought object
			if (Physics.Raycast (ray, out hit, distanceToCollect)
				&& hit.collider == collide) {

				//Access the variable holding the score from the ScoreManager script 
				//via the ScoreManager Singleton "Instance," and adds to it
				//when a Thought has been collected
				ScoreManager.Instance.score++;

				//Destroys the Thought once it has been collected
				GameObject.Destroy (this.gameObject);

			}
		}
	
		//Ticks up the timer
		timer += Time.deltaTime;
	}

	//Update called once every physics frame
	void FixedUpdate ()
	{

		//Every time the timer reaches a certain value, this if-statement is triggered
		if (timer <= timeToChangeDirection) {

			//Randomly selects a new velocity and direction for the Thought to move in
			rbody.velocity = new Vector3 (Random.Range (-.5f, .5f), Random.Range (-.5f, .5f), Random.Range (-.5f, .5f));

			//Resets the timer
			timer = 0;
		}
	}
}
