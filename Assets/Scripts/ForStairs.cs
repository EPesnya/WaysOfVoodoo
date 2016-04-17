using UnityEngine;
using System.Collections;

public class ForStairs : MonoBehaviour {

    GameObject platform;

    void Start()
    {
        platform = this.transform.GetChild(0).gameObject;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            if (!HeroControls.grounded)
            {
                other.GetComponent<Animator>().SetBool("OnStairs", true);
                other.GetComponent<Animator>().speed = 0;
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            if (Input.GetKey("w"))
            {
                //HeroControls.canMove = false;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                platform.GetComponent<EdgeCollider2D>().isTrigger = true;
                other.GetComponent<Animator>().speed = 1;
                other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 0.05f);
            }
            if (Input.GetKey("s"))
            {
                //HeroControls.canMove = false;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                platform.GetComponent<EdgeCollider2D>().isTrigger = true;
                other.GetComponent<Animator>().speed = 1;
                other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.05f);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            platform.GetComponent<EdgeCollider2D>().isTrigger = false;
            other.GetComponent<Animator>().SetBool("OnStairs", false);
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            other.GetComponent<Animator>().speed = 1;
        }
    }

}
