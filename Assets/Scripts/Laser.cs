using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public GameObject rightJoyStick;
	public Rigidbody2D rb2d;
	private float xdistance;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rightJoyStick = GameObject.Find ("RightJoystick");
		if (rightJoyStick.GetComponent<Ball> ().xdistance != 0 && rightJoyStick.GetComponent<Ball> ().ydistance != 0) 
		{
			transform.eulerAngles = new Vector3 (0, 0, Mathf.Rad2Deg * Mathf.Atan (rightJoyStick.GetComponent<Ball> ().ydistance / rightJoyStick.GetComponent<Ball> ().xdistance));
		}

		xdistance = rightJoyStick.GetComponent<Ball> ().xdistance;
	
	}

	void FixedUpdate () 
	{
		if (xdistance < 0)
		{
			transform.position += transform.right * .1f;
		} 
		else 
		{
			transform.position += -transform.right * .1f;
		}
	}
}
