using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2d;
	public GameObject leftJoyStick;
	public GameObject rightJoyStick;
	public GameObject laser;
	float xDirection = 0;
	float yDirection = 0;

	int count = 0;
	int count2 = 0;


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

		//*********FOR KEYBOARD ONLY

		//MOVEMENT + DIRECTION
		if (Input.GetKey ("w") && transform.position.y <= 4f) {
			yDirection = 0.25f;
			transform.eulerAngles = new Vector3 (0, 0, 0);
		} else if (Input.GetKey ("s") && transform.position.y >= -4f) {
			yDirection = -0.25f;
			transform.eulerAngles = new Vector3 (0, 0, 180);
		} else {
			yDirection = 0;
		}

		if (Input.GetKey ("d") && transform.position.x <= 8f) {
			xDirection = 0.25f;
			transform.eulerAngles = new Vector3 (0, 0, -90);
		} else if (Input.GetKey ("a") && transform.position.x >= -8f) {
			transform.eulerAngles = new Vector3 (0, 0, 90);
			xDirection = -0.25f;
		} else {
			xDirection = 0;
		}

		if (Input.GetKey ("w") && Input.GetKey ("d")) 
		{
			transform.eulerAngles = new Vector3 (0, 0, -45);
		}

		if (Input.GetKey ("w") && Input.GetKey ("a")) 
		{
			transform.eulerAngles = new Vector3 (0, 0, 45);
		}

		if (Input.GetKey ("a") && Input.GetKey ("s")) 
		{
			transform.eulerAngles = new Vector3 (0, 0, 135);
		}

		if (Input.GetKey ("s") && Input.GetKey ("d")) 
		{
			transform.eulerAngles = new Vector3 (0, 0, -135);
		}

		rb2d.transform.position = new Vector3 (transform.position.x + xDirection, 
											   transform.position.y + yDirection,
											   transform.position.z);

		//LASER INSTANTIATION
		if (count2 <=0 && (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))) 
		{
			Instantiate (laser, transform.position,Quaternion.identity);
			count2 = 10;
		}

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, 180);
		}

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, -90);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, 90);
		}

		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, -45);
		}

		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, 45);
		}

		if (Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, 135);
		}

		if (Input.GetKey (KeyCode.DownArrow) && Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.eulerAngles = new Vector3 (0, 0, -135);
		}
			
		if (count2 > 0) 
		{
			count2 -= 1;
		}

		//*******FOR KEYBOARD ONLY
	}
}
