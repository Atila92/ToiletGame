﻿ using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	public float powerPerPixel; // hvor meget skal der tilføjes per pixel swipe
	public float maxPower; // max power
	public float sensitivity; // sensitivitet på up og ned, side til side
	
	private Vector3 touchPos;
	Vector3 startPos;
	private bool isRolling; //  bool som bare forsætter om bolden er i bevægelse
	private float height;
	private float width;
	
	void Start () {
		isRolling = false;
		height =Camera.main.orthographicSize * 2;
		width = height * Screen.width/ Screen.height;

		transform.localScale = Vector3.one * height / 10f;
		startPos=transform.position;

	}
	
	void Update () {
		if (!isRolling) {
			if (Input.GetMouseButtonDown(0)) {
				touchPos = Input.mousePosition; // gemmer første touch
				
			}  else if (Input.GetMouseButtonUp(0)) {
				isRolling = true; //bool til true
				Vector3 releasePos = Input.mousePosition;
				float swipeDistanceY = releasePos.y - touchPos.y; // swipe på Y
				float power = powerPerPixel; //sætter power til powerPerPixel
				float swipeDistanceX = releasePos.x - touchPos.x; // swipe på X

				float throwDirection1 = swipeDistanceX * sensitivity; // X retning ganget med sensitivity som skal bruges til at addforce til bolden 
				float throwDirection2 = swipeDistanceY * sensitivity; // y retning ganget med sensitivity som skal bruges til at addforce til bolden 
				
				if (power < 0) {
					power *= -1; // hurtigt check på om power er negative og laver den positiv hvis den er.
				}
				if (power > maxPower) {
					power = maxPower; // sikre at power ikke kommer over Maxpower
				}
				rigidbody.AddForce(new Vector3(throwDirection1, throwDirection2, 0), 0); // adder force til bolden
				isRolling = false; //resetter vore bool til false så vi kan resette bolden
			}
		}
	}

	public void OnBecameInvisible() { //metode som bliver kald når bolden ikke kan ses, og resetter bolden så den er klar til at rolle igen
		transform.position=startPos;
		rigidbody.velocity = Vector3.zero;
		transform.localScale = Vector3.one * height / 10f;
	}
}
