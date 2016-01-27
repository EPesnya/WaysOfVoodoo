using UnityEngine;
using System.Collections;

public class HeroControls : MonoBehaviour {

    GameObject Ground;

    void Strat()
    {
        Ground = GameObject.FindGameObjectWithTag("Respawn");
    }

	void Update () 
    {
        Vector2 curVelocity = this.GetComponent<Rigidbody2D>().velocity;
	    if(Input.GetKey("d"))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(1, curVelocity.y);
        }
        else if(Input.GetKey("a"))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, curVelocity.y);
        }
        if (Input.GetKey("w"))// && Ground.GetComponent<Collider2D>().bounds.Contains(transform.GetChild(0).position))
        {
            Debug.Log(11);
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20), ForceMode2D.Force);
        }
	}
}
