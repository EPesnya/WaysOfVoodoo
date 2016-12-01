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

    GameObject[] Enemies;
    Vector2 prevPos;
    InputController InputController;
    void Flip()
    {
        this.transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 1);
    }

    void setBarFill(Transform barFill, float part)
    {
        barFill.localScale = new Vector2(part, 1);
        barFill.localPosition = new Vector2(-0.5f + 0.5f * part, 0);

    }

    public void setDeltaHP(float a)
    {
        if (a < 0)
            Camera.main.GetComponent<CameraFollow>().getHit(a);
        currentHP += a;
        setBarFill(HPBarFill, currentHP / HP);
    }

    float curSpeed;
    Vector2 curVelocity;
    bool onStairs = false, onStairsMove = false;
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        HPBar = Camera.main.transform.GetChild(5);
        HPBarFill = HPBar.transform.GetChild(0);
        HPBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32(240, 120, 16, 255);//??
        normalDepth = Camera.main.orthographicSize;
        prevPos = transform.position;
        InputController = GameObject.FindGameObjectWithTag("InputController").GetComponent<InputController>();
        InputController.Bind("d", new InputController.Action(() =>
        {
            curSpeed = speed * speedModifier;
            curVelocity = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector2(curSpeed, curVelocity.y);
            isWalking = true;
            if (!isLookToRight)
            {
                Flip();
                isLookToRight = true;
            }
            anim.SetBool("Walk", true);
        }))
        .Bind("a", new InputController.Action(() =>
        {
            curSpeed = speed * speedModifier;
            curVelocity = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-curSpeed, curVelocity.y);
            isWalking = true;
            if (isLookToRight)
            {
                Flip();
                isLookToRight = false;
            }
            anim.SetBool("Walk", true);
        }))
        .Bind("*|space", new InputController.Action(() =>
        {
            grounded = Physics2D.OverlapCircle(groundDetector.position, groundRadius, whatIsGround);
            if (grounded)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            }
        }))
        .Bind("!|a|d", new InputController.Action(() =>
        {
            grounded = Physics2D.OverlapCircle(groundDetector.position, groundRadius, whatIsGround);
            if (grounded)
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, curVelocity.y);
            isWalking = false;
            anim.SetBool("Walk", false);
        })).Bind("a|d", new InputController.Action(() =>
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, curVelocity.y);
            isWalking = false;
            anim.SetBool("Walk", false);
        })).
        Bind("w", new InputController.Action(() =>
        {
            gameObject.transform.position += new Vector3(0, 0.05f, 0);
            onStairsMove = true;
            anim.SetBool("OnStairs", true);
            anim.speed = 1;
        }, () => { return onStairs; }))
        .Bind("s", new InputController.Action(() =>
        {
            gameObject.transform.position -= new Vector3(0, 0.05f, 0);
            onStairsMove = true;
            anim.SetBool("OnStairs", true);
            anim.speed = 1;
        }, () => { return onStairs; }))
        .Bind("!|s|w", new InputController.Action(() =>
         {
             anim.speed = 0;
         }, () => { return onStairs && !onStairsMove; }));
    }

    void FixedUpdate()
    {
        guiScale = Camera.main.orthographicSize / normalDepth;
        Vector2 ScaleVector = new Vector2(normalLocalScale * guiScale, normalLocalScale * guiScale);
        HPBar.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, Screen.height * 0.95f));
        HPBar.position = new Vector3(HPBar.transform.position.x, HPBar.transform.position.y, 0);
        HPBar.localScale = ScaleVector;
        if((Vector2)transform.position != prevPos) 
            foreach (GameObject g in Enemies) 
                if(g != null) 
                    g.GetComponent<EnemyUnit>().OnPlayersMove(); 
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Stairs")
        {
            anim.SetBool("OnStairs", true);
            onStairs = true;
            if (onStairsMove)
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                collider.gameObject.transform.GetChild(0).GetComponent<EdgeCollider2D>().isTrigger = true;
            }
            else
            {
                anim.speed = 0;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Stairs")
        {
            onStairs = false;
            onStairsMove = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            collider.gameObject.transform.GetChild(0).GetComponent<EdgeCollider2D>().isTrigger = false;
            anim.SetBool("OnStairs", false);
            anim.SetBool("Walk", true);
        }
    }
}
