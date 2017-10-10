using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script determines how Thought objects will move,
//and allows them to be collected
public class InspirationThoughtBehavior : MonoBehaviour
{
	//The rigidbody of the Inspiration Thought object
	Rigidbody rbody;

	//The collider of the Inspiration Thought object
	public Collider collide;

	//The distance away from a thought object the player has to be
	//in order to collect it
	public float distanceToCollect;

	//These floats are used to calculate how long a Inspiration Thought should
	//exist before disappearing
	float timer;
	public float timeToVanish;

	// Use this for initialization
	void Start ()
	{
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

			//Checks if the ray hit a Inspiration Thought object
			if (Physics.Raycast (ray, out hit, distanceToCollect)
				&& hit.collider == collide) {

				//Access the variable holding the score from the ScoreManager script 
				//via the ScoreManager Singleton "Instance," and adds to it
				//when a Thought has been collected
				ScoreManager.Instance.score += 3;

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
		//Causes the Inspiration Thought object to continually flutter around
		//in a new random direction every physics frame
		rbody.velocity = new Vector3 (Random.Range (-5, 5), Random.Range (-2, 2), Random.Range (-5, 5));

		//Keeps the Thought from getting too close to the ground
		if (this.GetComponent<Transform>().position.y < 1f) {

			//Gets the X and Z coordinates of the Thought, which will be put back into
			//it's position
			float xPos = this.GetComponent<Transform>().position.x;
			float zPos = this.GetComponent<Transform>().position.z;

			//Moves the thought object to where it should be
			this.GetComponent<Transform>().position = new Vector3 (xPos, 1f, zPos);
		}
	}
}

