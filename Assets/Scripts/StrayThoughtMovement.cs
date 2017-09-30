using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrayThoughtMovement : MonoBehaviour {

	Rigidbody rbody;

	// Use this for initialization
	void Start () {
		rbody = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Update called once every physics framw
	void FixedUpdate() {
		rbody.velocity = new Vector3 (Random.Range (-5, 5), Random.Range (-5, 5), Random.Range (-5, 5));
	}
}
