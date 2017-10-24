using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;	//Allows this script to talk to UI text

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
	float thoughtTimer;
	public float timeToVanish;

	//A variable altered by the thought pulse behavior script to let a thought know when it's
	//lifetime should start counting down. This occurs after a player has walked into a thought pulse trigger
	//and caused a bunch of Inspiration Thoughts to appear around them
	public bool startTimer;

	//This is the reticile GameObject, which changes color when the player is within
	//pickup range of a Thought object
	public GameObject reticle;

	// Use this for initialization
	void Start ()
	{
		rbody = this.GetComponent<Rigidbody> ();

		thoughtTimer = 0f;

		//Specifies what "reticle" is
		reticle = GameObject.Find("Reticle");

		//Makes sure that this Inspiration Thought object stays out of the play space until
		//the player steps into a thought pulse trigger
		//this.GetComponent<Transform> ().position = new Vector3 (0f, -100f, 0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Generates a ray out from the camera
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		//Checks if the ray hit a Inspiration Thought object
		if (Physics.Raycast (ray, out hit, distanceToCollect)
		     && hit.collider == collide) {

			//Changes the reticle color
			reticle.GetComponent<Text> ().color = Color.red;

			//Checks if the player is clicking to collect an object
			if (Input.GetKey (KeyCode.Mouse0)) {

				//Access the variable holding the score from the ScoreManager script 
				//via the ScoreManager Singleton "Instance," and adds to it
				//when a Thought has been collected
				GameManager.Instance.score += 3;

				//Returns the reticle to it's normal color
				reticle.GetComponent<Text> ().color = Color.black;

				//Destroys the Thought once it has been collected
				GameObject.Destroy (this.gameObject);

			}
		}

		//Makes sure the Inspiration has been summoned to a thought pulse trigger.
		//before it's lifetime starts counting down. It would be pointless for the thought to
		//be destroyed before the player ever encounters it.
		if (startTimer == true) {
			
			//Ticks up the timer
			thoughtTimer += Time.deltaTime;
		}

		//If the THOUGHT TIMER reaches a certain value, the thought is destroyed
		if (thoughtTimer > timeToVanish) {
			GameObject.Destroy (this.gameObject);
		}

		//Removes the Thought from the scene when the GAME TIMER has run to zero,
		//as determined in the game manager
		if (GameManager.Instance.timesUp == true) {
			this.gameObject.SetActive (false);
		}
	}

	//Update called once every physics frame
	void FixedUpdate ()
	{
		//Causes the Inspiration Thought object to continually flutter around
		//in a new random direction every physics frame
		rbody.velocity = new Vector3 (Random.Range (-5, 5), Random.Range (-2, 2), Random.Range (-5, 5));

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

