using UnityEngine;
using System.Collections;

public class ballmov : MonoBehaviour {

	public float speed;

	void FixedUpdate()
	{
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		transform.rotation = rot;



		                                       
		float input = Input.GetAxis ("Vertical");
		rigidbody.AddForce (gameObject.transform.up * speed * input);
	}


}
