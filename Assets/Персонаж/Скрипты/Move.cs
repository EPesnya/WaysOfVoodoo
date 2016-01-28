using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float maxSpeed = 3f;
    bool fRight = true;
    Animator anim;

	// Use this for initialization
	void Start () {
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0 && !fRight)
        {
            Flip();
        }
        if (move < 0 && fRight)
        {
            Flip();
        }
	}

    void Flip()
    {
        fRight = !fRight;
        Vector3 tScale = transform.localScale;
        tScale.x *= -1;
        transform.localScale = tScale;
    }
}
