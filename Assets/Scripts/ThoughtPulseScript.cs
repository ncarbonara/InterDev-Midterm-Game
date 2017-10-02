using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtPulseScript : MonoBehaviour
{

	public GameObject thought;
	public int numberOfThoughts;
	Vector3 triggerPosition;
	public GameObject inspirationAlertText;

	// Use this for initialization
	void Start ()
	{
		triggerPosition = this.GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter ()
	{
		inspirationAlertText.SetActive(true);

		for (int i = 0; i < numberOfThoughts; i++) {
			//The following three floats are used spawn the Thought objects at random distances from the center of the trigger,
			//Rather than directly at it's center
			float randomSpawnOffsetX = Random.Range (-2, 2);
			float randomSpawnOffsetY = Random.Range (-2, 2);
			float randomSpawnOffsetZ = Random.Range (-2, 2);

			//Spawns a new thought object
			Instantiate (thought, new Vector3(triggerPosition.x + randomSpawnOffsetX, 
				triggerPosition.y + randomSpawnOffsetY, 
				triggerPosition.z + randomSpawnOffsetZ), Quaternion.identity);
		}

		//Destroys the trigger once it has been used, so that it can't be used again
		GameObject.Destroy (this);
	}
}
