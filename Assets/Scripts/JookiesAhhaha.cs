using UnityEngine;
using System.Collections;

public class JookiesAhhaha : MonoBehaviour {

    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!HeroControls.grounded)
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                other.GetComponent<Animator>().SetBool("OnStairs", true);
            }
            if (other.GetComponent<Animator>().GetBool("OnStair"))
            {
                other.GetComponent<Animator>().speed = 0;
            }
            if (Input.GetKey("w"))
            {
                //HeroControls.canMove = false;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 0.05f);
                
                if(other.GetComponent<Animator>().GetBool("OnStair"))
                {
                    other.GetComponent<Animator>().speed = 1; 
                }
            }
            if (Input.GetKey("s"))
            {
                //HeroControls.canMove = false;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.05f);

                if (other.GetComponent<Animator>().GetBool("OnStair"))
                {
                    other.GetComponent<Animator>().speed = -1;
                }
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
