using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script determines how Thought objects will move,
//and allows them to be collected
public class ThoughtBehavior : MonoBehaviour
{
	//The rigidbody of the thought object
	Rigidbody rbody;

	//The player character; Commented out, in case it's needed later in development
	//GameObject player;

	//The distance away from a thought object the player has to be
	//in order to collect it
	public float distanceToCollect;

	//These floats are used to calculate how long a thought should
	//exist before disappearing
	float timer;
	public float timeToVanish;

	// Use this for initialization
	void Start ()
	{
		//Commented out, in case it's needed later in development
		//player = GameObject.Find ("Player");

		rbody = this.GetComponent<Rigidbody> ();

		timer = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Checks if the player is clicking to collect an object
		if (Input.GetKey (KeyCode.Mouse0)) {
		
			//Generates a ray out from the camera
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			//Checks if the ray hit a Thought object
			if (Physics.Raycast (ray, out hit, distanceToCollect)
				&& hit.collider == this.GetComponent<Collider>()) {

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

		//If the timer reaches a certain value, the thought is destroyed
		if (timer > timeToVanish) {
			GameObject.Destroy (this.gameObject);
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
