using UnityEngine;
using System.Collections;

public class ballmov2 : MonoBehaviour {

	public Transform player; // Drag your player here
	private Vector2 fp; // first finger position
	private Vector2 lp; // last finger position
	private float angle;
	private float swipeDistanceX;
	private float swipeDistanceY;
	
	void Update () {
		foreach(Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				fp = touch.position;
				lp = touch.position;
			}
			if (touch.phase == TouchPhase.Moved )
			{
				lp = touch.position;
				swipeDistanceX = Mathf.Abs((lp.x-fp.x));
				swipeDistanceY = Mathf.Abs((lp.y-fp.y));
			}
			if(touch.phase == TouchPhase.Ended)
			{
				angle = Mathf.Atan2((lp.x-fp.x),(lp.y-fp.y))*57.2957795f;
				
				if(angle > 60 && angle < 120 && swipeDistanceX > 40    )
				{
					print ("right");
					player.Rotate(0,45,0);
					player.position+=new Vector3(2,0,0);
				}
				if(angle > 150 || angle < -150 && swipeDistanceY > 40)
				{
					print ("down");
					player.position+=new Vector3(0,-2,0);
					player.Rotate(0,0,45);
				}
				if(angle < -60 && angle > -120 && swipeDistanceX > 40)
				{
					print ("left");
					player.Rotate(0,-45,0);
					player.position+=new Vector3(-2,0,0);
				}
				if(angle > -30 && angle < 30 && swipeDistanceY > 40)
				{
					print ("up");
					player.position+=new Vector3(0,2,0);
					player.Rotate(0,0,-45);
				}
			}
		}
	}
}
