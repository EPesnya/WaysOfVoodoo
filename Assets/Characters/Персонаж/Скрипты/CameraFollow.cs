using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float speed = 5;
    public float verticalShift = 3;
    public static bool isFollowing = true;
    public static Vector2 TargetPos;
    public float defaultScale;
    public static float targetScale;
    GameObject Player;

	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () 
    {
        if (isFollowing)
        {
            GetComponent<Rigidbody2D>().velocity = (new Vector2(Player.transform.position.x, Player.transform.position.y + verticalShift) - (Vector2)transform.position);
            this.GetComponent<Camera>().orthographicSize += (defaultScale - this.GetComponent<Camera>().orthographicSize) * 0.01f;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = ((Vector2)CameraFollow.TargetPos - (Vector2)transform.position);
            this.GetComponent<Camera>().orthographicSize += (CameraFollow.targetScale - this.GetComponent<Camera>().orthographicSize) * 0.01f;
        }
	}
}