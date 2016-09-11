using UnityEngine;
using System.Collections;

public class FireballFollow : MonoBehaviour {

    public Transform Anchor;

	void Update () 
    {
        this.GetComponent<Rigidbody2D>().velocity = 4 * (Anchor.position - transform.position);
	}
}
