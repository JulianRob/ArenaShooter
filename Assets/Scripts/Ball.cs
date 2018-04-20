using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D hook;
	public Text distText;

	private float maxDragDistance = 1f;
	public float xdistance = 0;
	public float ydistance = 0;
	private bool isPressed = false;
	private Vector3 initialPosition;
	private Vector2 touchPos;
	private float distance;
	private float distance2;

	private float stretch = 1.5f;

	void Start()
	{
		initialPosition = transform.position;
	}

	void Update ()
	{

		//Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position)
		if (Input.touchCount > 0) 
		{
			distance = Vector3.Distance (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), initialPosition);
			distText.text = "" + distance;
			if (distance <= 11f) {
				isPressed = true;
				rb.isKinematic = true;
				touchPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			} else if (Input.touchCount > 1) {
				distance2 = Vector3.Distance (Camera.main.ScreenToWorldPoint (Input.GetTouch (1).position), initialPosition);
				if (distance2 <= 11f) {
					isPressed = true;
					rb.isKinematic = true;
					touchPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (1).position);
				} else {
					isPressed = false;
					rb.isKinematic = false;
				}
			} else {
				isPressed = false;
				rb.isKinematic = false;
			}

		}
		else 
		{
			isPressed = false;
			rb.isKinematic = false;
		}
			
		if (isPressed)
		{
			if (Vector3.Distance (touchPos, hook.position) > maxDragDistance) {
				rb.position = hook.position + (touchPos - hook.position).normalized * maxDragDistance;
			} else {
				rb.position = touchPos;
			}

			xdistance = initialPosition.x - transform.position.x;
			ydistance = initialPosition.y - transform.position.y;
		}
		else
		{
			xdistance = 0;
			ydistance = 0;
		}

		//*********FOR KEYBOARD ONLY
		if (rb.position.x <= 0) 
		{
			if (Input.GetKey ("w") || Input.GetKey ("d") || Input.GetKey ("s") || Input.GetKey ("a")) 
			{
				rb.isKinematic = true;

				if (Input.GetKey ("w")) 
				{
					rb.position = new Vector2 (initialPosition.x, initialPosition.y + stretch);
				} 

				if (Input.GetKey ("s")) 
				{
					rb.position = new Vector2 (initialPosition.x, initialPosition.y - stretch);
				} 

				if (Input.GetKey ("d"))
				{
					rb.position = new Vector2 (initialPosition.x+stretch, initialPosition.y);
				}

				if (Input.GetKey ("a")) 
				{
					rb.position = new Vector2 (initialPosition.x-stretch, initialPosition.y);
				} 

				if (Input.GetKey ("w") && Input.GetKey ("d")) 
				{
					rb.position = new Vector2 (initialPosition.x + Mathf.Cos(Mathf.Deg2Rad*45)*stretch, initialPosition.y + Mathf.Sin(Mathf.Deg2Rad*45)*stretch);
				}

				if (Input.GetKey ("w") && Input.GetKey ("a")) 
				{
					rb.position = new Vector2 (initialPosition.x - Mathf.Cos(Mathf.Deg2Rad*45)*stretch, initialPosition.y + Mathf.Sin(Mathf.Deg2Rad*45)*stretch);
				}

				if (Input.GetKey ("a") && Input.GetKey ("s")) 
				{
					rb.position = new Vector2 (initialPosition.x - Mathf.Cos(Mathf.Deg2Rad*45)*stretch, initialPosition.y - Mathf.Sin(Mathf.Deg2Rad*45)*stretch);
				}

				if (Input.GetKey ("s") && Input.GetKey ("d")) 
				{
					rb.position = new Vector2 (initialPosition.x + Mathf.Cos(Mathf.Deg2Rad*45)*stretch, initialPosition.y - Mathf.Sin(Mathf.Deg2Rad*45)*stretch);
				}

			} 
			else 
			{
				rb.isKinematic = false;
			}
		}

		if (rb.position.x >= 0) 
		{
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) 
			{
				rb.isKinematic = true;

				if (Input.GetKey (KeyCode.UpArrow)) 
				{
					rb.position = new Vector2 (initialPosition.x, initialPosition.y + stretch);
				}

				if (Input.GetKey (KeyCode.DownArrow)) 
				{
					rb.position = new Vector2 (initialPosition.x, initialPosition.y - stretch);
				}

				if (Input.GetKey (KeyCode.RightArrow)) 
				{
					rb.position = new Vector2 (initialPosition.x+stretch, initialPosition.y);
				}

				if (Input.GetKey (KeyCode.LeftArrow)) 
				{
					rb.position = new Vector2 (initialPosition.x-stretch, initialPosition.y);
				}

				if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.RightArrow)) 
				{
					rb.position = new Vector2 (initialPosition.x + Mathf.Cos(Mathf.Deg2Rad*45)*stretch, initialPosition.y + Mathf.Sin(Mathf.Deg2Rad*45)*stretch);
				}

				if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.LeftArrow)) 
				{
					rb.position = new Vector2 (initialPosition.x - Mathf.Cos(Mathf.Deg2Rad*45)*stretch, initialPosition.y + Mathf.Sin(Mathf.Deg2Rad*45)*stretch);
				}

				if (Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.DownArrow)) 
				{
					rb.position = new Vector2 (initialPosition.x - Mathf.Cos(Mathf.Deg2Rad*45)*stretch, initialPosition.y - Mathf.Sin(Mathf.Deg2Rad*45)*stretch);
				}

				if (Input.GetKey (KeyCode.DownArrow) && Input.GetKey (KeyCode.RightArrow)) 
				{
					rb.position = new Vector2 (initialPosition.x + Mathf.Cos(Mathf.Deg2Rad*45)*stretch, initialPosition.y - Mathf.Sin(Mathf.Deg2Rad*45)*stretch);
				}

			} 
			else 
			{
				rb.isKinematic = false;
			}
		}
		//*********FOR KEYBOARD ONLY
	}
}
