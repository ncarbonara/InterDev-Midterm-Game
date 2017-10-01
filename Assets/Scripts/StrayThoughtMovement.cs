using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrayThoughtMovement : MonoBehaviour
{

	Rigidbody rbody;

	public GameObject player;

	public float distanceToCollect;

	// Use this for initialization
	void Start ()
	{
		rbody = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Vector3.Distance (player.GetComponent<Transform> ().position, this.GetComponent<Transform> ().position) < distanceToCollect
			&& Input.GetKey(KeyCode.Mouse0)) {
			//	destroy thought;
			// give player points or other goodies;
			Destroy(this);
		}
	}

	//Update called once every physics framw
	void FixedUpdate ()
	{
		rbody.velocity = new Vector3 (Random.Range (-5, 5), Random.Range (-5, 5), Random.Range (-5, 5));
	}
}
