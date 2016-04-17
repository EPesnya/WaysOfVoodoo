using UnityEngine;
using System.Collections;

public class JookiesAhhaha : MonoBehaviour {

    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!HeroControls.grounded)
            other.GetComponent<Animator>().SetBool("OnStairs", true);
            if (Input.GetKey("w"))
            {
                //HeroControls.canMove = false;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 0.05f);
            }
            if (Input.GetKey("s"))
            {
                //HeroControls.canMove = false;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.05f);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Animator>().SetBool("OnStairs", false);
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
