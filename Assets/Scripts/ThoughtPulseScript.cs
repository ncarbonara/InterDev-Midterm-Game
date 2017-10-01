using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtPulseScript : MonoBehaviour {

	public GameObject thought;
	public int numberOfThoughts;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter() {

		for (int i = 0; i < numberOfThoughts; i++) {
		Instantiate (thought);
	}
}
}
