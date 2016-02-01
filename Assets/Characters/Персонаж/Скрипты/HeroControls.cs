using UnityEngine;
using System.Collections;

public class HeroControls : MonoBehaviour {

    GameObject Ground;
    public Animator anim;
    float speed = 0;
    bool isWalking = false;
    bool isLookToRight = true;
    public float maxSpeed = 3;
    float starPrepJump;
    float jumpDelay = 0.3f;
    bool shouldJump;

    void Strat()
    {
        //anim = this.GetComponent<Animator>();
        Ground = GameObject.FindGameObjectWithTag("Respawn");
    }

    void Flip()
    {
        this.transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
    }

	void FixedUpdate () 
    {
        speed *= 0.9f;
        Vector2 curVelocity = this.GetComponent<Rigidbody2D>().velocity;
        if (Input.GetKey("d"))
        {
            speed += 0.3f;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if (Input.GetKey("a"))
        {
            speed -= 0.3f;
            if (speed < -maxSpeed)
            {
                speed = -maxSpeed;
            }
        }

        if (speed < 0 && isLookToRight)
        {
            Flip();
            isLookToRight = false;
        }
        if (speed > 0 && !isLookToRight)
        {
            Flip();
            isLookToRight = true;
        }

        if (Input.GetKeyDown("w"))// && Ground.GetComponent<Collider2D>().bounds.Contains(transform.GetChild(0).position))
        {
            starPrepJump = Time.time;
            shouldJump = true;
            anim.SetTrigger("Jump");
        }
        if (Time.time - starPrepJump > jumpDelay && shouldJump)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500), ForceMode2D.Force);
            shouldJump = false;
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, curVelocity.y);
        anim.SetFloat("MovementSpeed", Mathf.Abs(speed));

        if(Mathf.Abs(speed) < 0.1f && isWalking)
        {
            //anim.Play("Rest", -1, 0);
            isWalking = false;
        }
        if (Mathf.Abs(speed) > 0.1f && !isWalking)
        {
            //anim.Play("Walk", -1, 0);
            isWalking = true;
        }
	}
}
