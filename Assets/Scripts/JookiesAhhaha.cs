using UnityEngine;
using System.Collections;

public class JookiesAhhaha : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey("w"))
        {
            other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 0.05f);
        }
        if (Input.GetKey("s"))
        {
            other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.05f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
