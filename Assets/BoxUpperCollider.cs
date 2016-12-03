using UnityEngine;
using System.Collections;

public class BoxUpperCollider : MonoBehaviour {

	BoxCollider2D lowerCollider;

	void Start() 
	{
		lowerCollider = transform.parent.
				GetChild(0).GetComponent<BoxCollider2D>();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Player" && !lowerCollider.GetComponent<BoxLowerCollider>().isStaying)
		{
			lowerCollider.isTrigger = false;
			lowerCollider.gameObject.layer = 8;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			lowerCollider.isTrigger = true;
			lowerCollider.gameObject.layer = 0;
		}
	}
}
