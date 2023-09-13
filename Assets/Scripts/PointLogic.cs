using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLogic : MonoBehaviour
{

	public int PointCount;
	public GameObject player;
	
	// when Player collides with point
	void OnTriggerEnter(Collider other)
	{

		if (other.name == "Pac Racer X" ) {
			GameLogic.Instance.Score++;

			Destroy(this.gameObject, 0.25f);
		}

	}
}
