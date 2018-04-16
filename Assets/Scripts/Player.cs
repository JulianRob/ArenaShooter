using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2d;
	public GameObject leftJoyStick;
	public GameObject rightJoyStick;
	public GameObject laser;

	int count = 0;


	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}


	void FixedUpdate () 
	{
		rb2d.transform.position = new Vector3 (transform.position.x - (leftJoyStick.GetComponent<Ball> ().xdistance)/4,
											   transform.position.y - (leftJoyStick.GetComponent<Ball> ().ydistance)/4, 
											   transform.position.z);

		if (rightJoyStick.GetComponent<Ball> ().xdistance != 0 && rightJoyStick.GetComponent<Ball> ().ydistance != 0 && count <= 0) 
		{
			Instantiate (laser, transform.position,Quaternion.identity);
			count = 10;
		}

		if (count > 0) 
		{
			count -= 1;
		}
	}
}
