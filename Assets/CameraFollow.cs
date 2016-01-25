using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float speed = 5;
    public float verticalShift = 3;
    GameObject Player;

	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () 
    {
        GetComponent<Rigidbody2D>().velocity = (new Vector2(Player.transform.position.x, Player.transform.position.y + verticalShift) - (Vector2)transform.position) * speed;
	}
}