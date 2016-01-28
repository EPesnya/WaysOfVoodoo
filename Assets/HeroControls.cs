using UnityEngine;
using System.Collections;

public class HeroControls : MonoBehaviour {

    GameObject Ground;
    public Animator anim;
    float speed = 0;
    bool isWalking = false;
    bool isLookToRight = true;

    void Strat()
    {
        //anim = this.GetComponent<Animator>();
        Ground = GameObject.FindGameObjectWithTag("Respawn");
    }

    void Flip()
    {
        this.transform.localScale = new Vector2(-1 * transform.localScale.x, 1);
    }

	void FixedUpdate () 
    {
        speed *= 0.9f;
        Vector2 curVelocity = this.GetComponent<Rigidbody2D>().velocity;
        if (Input.GetKey("d"))
        {
            speed += 0.1f;
            if(speed > 0.9f)
            {
                speed = 0.9f;
            }
        }
        else if (Input.GetKey("a"))
        {
            speed -= 0.1f;
            if (speed < -0.9f)
            {
                speed = -0.9f;
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
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300), ForceMode2D.Force);
            anim.SetTrigger("Jump");
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
