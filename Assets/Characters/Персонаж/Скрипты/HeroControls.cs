using UnityEngine;
using System.Collections;

public class HeroControls : MonoBehaviour {
    
    public static bool grounded;
    public Transform groundDetector;
    public Animator anim;
    float speed = 8;
    public float speedModifier = 1;
    public LayerMask whatIsGround;

    float HP = 100;
    float currentHP = 100;
    Transform HPBar;
    Transform HPBarFill;

    GameObject Ground;
    bool isWalking = false;
    bool isLookToRight = true;
    float jumpForce = 500;
    float groundRadius = 0.2f;

    float guiScale = 1;
    float normalDepth;
    float normalLocalScale = 5;

    void Flip()
    {
        this.transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 1);
    }

    void setBarFill(Transform barFill, float part)
    {
        barFill.localScale = new Vector2(part, 1);
        barFill.localPosition = new Vector2(-0.5f + 0.5f * part, 0);
    }

    public void setDeltaHP(int a)
    {
        currentHP += a;
        setBarFill(HPBarFill, currentHP / HP);
    }

    void Start()
    {
        HPBar = Camera.main.transform.GetChild(5);
        HPBarFill = HPBar.transform.GetChild(0);
        HPBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32(240, 120, 16, 255);//??
        normalDepth = Camera.main.orthographicSize;
    }

	void FixedUpdate () 
    {

        guiScale = Camera.main.orthographicSize / normalDepth;
        Vector2 ScaleVector = new Vector2(normalLocalScale * guiScale, normalLocalScale * guiScale);
        HPBar.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, Screen.height * 0.95f));
        HPBar.position = new Vector3(HPBar.transform.position.x, HPBar.transform.position.y, 0);
        HPBar.localScale = ScaleVector;

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
