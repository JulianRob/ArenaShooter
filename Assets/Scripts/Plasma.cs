using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasma : MonoBehaviour {

	GameObject player;
	float step;

	void Start()
	{
		player = GameObject.Find ("Player");
	}

	void Update () 
	{
		step = 1 * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.CompareTag ("Laser"))
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
