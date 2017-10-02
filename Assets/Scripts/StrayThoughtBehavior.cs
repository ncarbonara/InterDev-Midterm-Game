using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script determines how Thought objects will move,
//and allows them to be collected
public class StrayThoughtBehavior : MonoBehaviour
{
	//The rigidbody of the thought object
	Rigidbody rbody;

	//The player character
	GameObject player;

	//The Thought object itself
	public GameObject thoughtObject;

	//The distance away from a thought object the player has to be
	//in order to collect it
	public float distanceToCollect;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");

		rbody = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Checks if the player is in range of the thought object, and if they
		//are clicking to collect it
		if (Vector3.Distance (player.GetComponent<Transform> ().position, this.GetComponent<Transform> ().position) < distanceToCollect
			&& Input.GetKey(KeyCode.Mouse0)) {

			//Access the variable holding the score from the ScoreManager script 
			//via the ScoreManager Singleton "Instance," and adds to it
			//when a Thought has been collected
			ScoreManager.Instance.score++;

			//Destroys the Thought once it has been collected
			GameObject.Destroy(thoughtObject);
		}
	}

	//Update called once every physics frame
	void FixedUpdate ()
	{
		//Causes the Thought object to continually flutter around
		//in a new random direction every physics frame
		rbody.velocity = new Vector3 (Random.Range (-5, 5), Random.Range (-5, 5), Random.Range (-5, 5));
	}
}
