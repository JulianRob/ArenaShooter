using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

	public GameObject plasma;

	int count = 0;
	int[] randomXPositions = new int[] {-7,7};
	int[] randomYPositions = new int[] {4,2,0};

	void Start ()
	{
		
	}
	

	void FixedUpdate () 
	{
		if (count <= 0)
		{
			Instantiate (plasma, new Vector3 (randomXPositions [Random.Range (0, randomXPositions.Length)], randomYPositions [Random.Range (0, randomYPositions.Length)], 0), Quaternion.identity);
			count = 60;
		}

		if (count >= 0) 
		{
			count -= 1;
		}
	}
}
