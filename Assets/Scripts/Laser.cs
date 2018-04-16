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

		//ONLY FOR KEYBOARD

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.eulerAngles = new Vector3 (0, 0, 180);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.eulerAngles = new Vector3 (0, 0, -90);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.eulerAngles = new Vector3 (0, 0, 90);
		}

		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, -135);
		}

		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, -45);
		}

		if (Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, 135);
		}

		if (Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, 45);
		}

		//ONLY FOR KEYBOARD
	
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

		if (transform.position.x <= -11) 
		{
			Destroy(gameObject);
		}

		if (transform.position.x >= 10) 
		{
			Destroy(gameObject);
		}

		if (transform.position.y >= 7) 
		{
			Destroy(gameObject);
		}

		if (transform.position.y <= -7) 
		{
			Destroy(gameObject);
		}
	}
}
