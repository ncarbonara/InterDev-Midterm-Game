﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	//Remembers our vertical mouse look
	float verticalLook = 0f;

	//A value tracking how sensitive the mouse is
	public float mouseSensitivity;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//Checks how much the mouse is being moved both horizontally and vertically
		float mouseX = Input.GetAxis ("Mouse X");	//Ranges rom -1 to 1, not in screen coords
		float mouseY = Input.GetAxis ("Mouse Y");

		Vector2 mouseVector2 = Camera.main.ScreenToViewportPoint (new Vector2 (mouseX, mouseY));

		//These are the axes you're rotating ABOUT, that's why x is in y and y is in x

		//Horizontal rotation:
		transform.parent.Rotate(0f, mouseVector2.x * Time.deltaTime * mouseSensitivity, 0f);	//Character rotates with left/right

		//Standard vertical rotation:
		//transform.Rotate (-mouseVector2.y * Time.deltaTime * mouseSensitivity, 0f, 0f);		//Up/Down only rotates camera

		//Clamped vertical rotation:
		//FOOD FOR THOUGHT: Did this save my mouse reappearing problem?
		verticalLook -= mouseVector2.y * Time.deltaTime * mouseSensitivity;
		verticalLook = Mathf.Clamp (verticalLook, -85f, 85f);

		//Z override: To stop the camera from rolling around the z axis
		//We need to make a whole new Vector3, but we can feed bits of the old Vector3 (y) back into the new one
		transform.localEulerAngles = new Vector3(verticalLook, transform.localEulerAngles.y, 0f);

		if (Input.GetMouseButtonDown (0)) {		//0 = left click, 1 = right click, 2 = middle click
			//Cursor.visible = false;		//Hides cursor
			Cursor.lockState = CursorLockMode.Locked;	//Locks mouse cursor to center of window
		}
	}
}

