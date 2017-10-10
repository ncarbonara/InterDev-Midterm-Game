using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to cause a bunch of "Thought objects" for the player to collect
//to appear when the player passes through the trigger and have become "inspired"
public class ThoughtPulseBehavior : MonoBehaviour
{
	//A prefab for the Thought object
	public GameObject thought;

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
	}

	//Checks for collisions with the trigger
	void OnTriggerEnter (Collider col)
	{

		//Only activates if the player has entered the collider
		if (col.gameObject.name == playerCollider.gameObject.name) {
			
			//Causes the inspiration altert text to appear onscreen
			inspirationAlertText.SetActive (true);

			//A loop that instantiates one thought object for 
			for (int i = 0; i < numberOfThoughts; i++) {
		
				//The following three floats are used spawn the Thought objects at 
				//random distances from the center of the trigger,
				//Rather than directly at it's center
				float randomSpawnOffsetX = Random.Range (-2, 2);
				float randomSpawnOffsetY = Random.Range (-2, 2);
				float randomSpawnOffsetZ = Random.Range (-2, 2);

				//Spawns a new thought object
				Instantiate (thought, new Vector3 (triggerPosition.x + randomSpawnOffsetX, 
					triggerPosition.y + randomSpawnOffsetY, 
					triggerPosition.z + randomSpawnOffsetZ), Quaternion.identity);
			}

			//Destroys the trigger once it has been used, so that it can't be used again
			this.gameObject.SetActive (false);
		}
	}
}
