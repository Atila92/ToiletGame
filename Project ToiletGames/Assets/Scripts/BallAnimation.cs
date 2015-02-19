using UnityEngine;
using System.Collections;

public class BallAnimation : MonoBehaviour {

	public Transform sphere3D;
	public float ballRadius = 1;
	float c;
	Rigidbody rb;
	Vector3 axis;
	float angle;
	
	void Start () {
		c = 2*Mathf.PI*ballRadius;
		rb = rigidbody;
	}
	
	void Update () {
		axis = Vector3.Cross(rb.velocity, Vector3.forward);
		angle = (rb.velocity.magnitude*360/c);
		sphere3D.Rotate(axis, angle*Time.deltaTime, Space.World);
	}
}
