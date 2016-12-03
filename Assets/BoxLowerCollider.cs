using UnityEngine;
using System.Collections;

public class BoxLowerCollider : MonoBehaviour {
	public bool isStaying = false;
	void OnTriggerEnter2D(Collider2D other)
	{
		isStaying = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		isStaying = false;
	}
}
