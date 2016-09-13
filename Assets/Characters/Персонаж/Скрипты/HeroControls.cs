using UnityEngine;
using System.Collections;

public class HeroControls : MonoBehaviour {
    
    public static bool grounded;
    public Transform groundDetector;
    public Animator anim;
    float speed = 8;
    public float speedModifier = 1;
    public LayerMask whatIsGround;

    GameObject Ground;
    bool isWalking = false;
    bool isLookToRight = true;
    float jumpForce = 500;
    float groundRadius = 0.2f;

    void Flip()
    {
        this.transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 1);
    }

	void FixedUpdate () 
    {
        grounded = Physics2D.OverlapCircle(groundDetector.position, groundRadius, whatIsGround);
        float curSpeed = speed * speedModifier;
        Vector2 curVelocity = GetComponent<Rigidbody2D>().velocity;

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(curSpeed, curVelocity.y);
            isWalking = true;
            if (!isLookToRight)
            {
                Flip();
                isLookToRight = true;
            }
            anim.SetBool("Walk", true);
        }
        else if(Input.GetKey("a"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-curSpeed, curVelocity.y);
            isWalking = true;
            if(isLookToRight)
            {
                Flip();
                isLookToRight = false;
            }
            anim.SetBool("Walk", true);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, curVelocity.y);
            isWalking = false;
            anim.SetBool("Walk", false);
        }
        if (Input.GetKeyDown("space") && grounded)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
	}
}
