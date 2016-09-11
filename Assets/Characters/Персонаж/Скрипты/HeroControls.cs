using UnityEngine;
using System.Collections;

public class HeroControls : MonoBehaviour {
    
    public static bool grounded;
    public Transform groundDetector;
    public Transform groundDetector1;
    public Animator anim;
    public float speed = 8;
    public LayerMask whatIsGround;
    public GameObject FireBall;

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
        grounded = Physics2D.OverlapCircle(groundDetector.position, groundRadius, whatIsGround)
                    || Physics2D.OverlapCircle(groundDetector1.position, groundRadius, whatIsGround);

        Vector2 curVelocity = GetComponent<Rigidbody2D>().velocity;

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, curVelocity.y);
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, curVelocity.y);
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

        ////////////////
        if (Input.GetKeyDown("f"))
        {
            GameObject tmp;
            tmp = Instantiate(FireBall, this.transform) as GameObject;
            tmp.transform.position = new Vector2(transform.position.x + transform.localScale.x, transform.position.y);
            tmp.transform.parent = null;
            tmp.transform.localScale = new Vector3(3, 3, 1);
            tmp.GetComponent<Rigidbody2D>().velocity = new Vector2(15 * transform.localScale.x, 0);

        }
	}
}
