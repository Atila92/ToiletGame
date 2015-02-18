﻿using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	public float powerPerPixel; //  force per one pixel flick 
	public float maxPower; // force limiter
	public float sensitivity; // the higher, the more control to the right and left
	
	private Vector3 touchPos;
	private bool isRolling; //  true after throwing the ball
	
	void Start () {
		isRolling = false;
	}
	
	void Update () {
		if (!isRolling) {
			if (Input.GetMouseButtonDown(0)) {
				touchPos = Input.mousePosition; // remember the initial touch position
				
			}  else if (Input.GetMouseButtonUp(0)) {
				isRolling = true; //stop detecting touches
				Vector3 releasePos = Input.mousePosition;
				float swipeDistanceY = releasePos.y - touchPos.y; // flicking distance in Y-axis
				float power = swipeDistanceY * powerPerPixel;
				float swipeDistanceX = releasePos.x - touchPos.x; // flicking distance in X-axis
				float throwDirection = swipeDistanceX * sensitivity;
				
				if (power < 0) {
					power *= -1; // invert the sign if the value is negative
				}
				if (power > maxPower) {
					power = maxPower; // apply force limiter
				}
				rigidbody.AddForce(new Vector3(throwDirection, 0, power), ForceMode.Impulse); // apply force to the ball
			}
		}
	}
}
