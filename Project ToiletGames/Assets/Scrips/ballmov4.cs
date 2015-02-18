using UnityEngine;
using System.Collections;
public class ballmov4 : MonoBehaviour {
	private Vector3 throwSpeed = new Vector3(0, 0, 0);
	public GameObject ballReference;
	private Vector2 startPos;
	private Vector2 endPos;
	private Vector2 minDistance = new Vector2(0, 100);
	private Vector3 ballPos = new Vector3(0, 0.38f, -11.41f);
	public bool ballOnStage = false;


	
	void Update()
	{
		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Began)
			{
				startPos = touch.position;
			}
			if(touch.phase == TouchPhase.Ended)
			{
				endPos = touch.position;
			}
			
			/* Compare positions */
			
			if(endPos.y - startPos.y >= minDistance.y && !ballOnStage )
			{

				/* Center */
				if(touch.position.x > Screen.width&& touch.position.x <= (Screen.width) * 2)
				{
					ballPos.x = Random.Range(-0.35f, 0.22f);
				}
				
				GameObject ball = Instantiate(ballReference, ballPos, transform.rotation) as GameObject;
				ball.rigidbody.AddForce(throwSpeed);

				
				endPos = new Vector2(0, 0);
				startPos = new Vector2(0, 0);
				ballOnStage = true;
			}
		}
	}
}