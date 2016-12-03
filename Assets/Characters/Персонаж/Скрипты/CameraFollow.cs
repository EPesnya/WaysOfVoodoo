using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float speed = 5;
    public float verticalShift = 3;
    public static bool isFollowing = true;
    public static Vector2 TargetPos;
    public float defaultScale;
    public static float targetScale;
    GameObject Player;

    float lastDamageTakingTime = -100;
    float lastDamageAmount = 0;

    System.Random o = new System.Random();
    GameObject Mask;

    public void getHit(float damage)
    {
        if(Time.time - lastDamageTakingTime < 1)
        {
            Mask.GetComponent<SpriteRenderer>().color = new Color(Mask.GetComponent<SpriteRenderer>().color.r,
                Mask.GetComponent<SpriteRenderer>().color.g, Mask.GetComponent<SpriteRenderer>().color.b,
                Mask.GetComponent<SpriteRenderer>().color.a + 0.04f);
        }
        else
        {
            float angle = (float)o.NextDouble() * 6.28318f;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * damage * 0.1f, ForceMode2D.Force);
            Mask.GetComponent<SpriteRenderer>().color = new Color(Mask.GetComponent<SpriteRenderer>().color.r,
                Mask.GetComponent<SpriteRenderer>().color.g, Mask.GetComponent<SpriteRenderer>().color.b,
                Mask.GetComponent<SpriteRenderer>().color.a + 0.5f * Mathf.Sqrt(-damage * 0.1f));
        }
        lastDamageTakingTime = Time.time;
        lastDamageAmount = damage;
    }

	void Start () 
    {
        Mask = transform.GetChild(6).gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate ()
    {
        if(Time.time - lastDamageTakingTime > 1)
            Mask.GetComponent<SpriteRenderer>().color = new Color(Mask.GetComponent<SpriteRenderer>().color.r,
                Mask.GetComponent<SpriteRenderer>().color.g, Mask.GetComponent<SpriteRenderer>().color.b,
                Mask.GetComponent<SpriteRenderer>().color.a - 0.015f);
        if (Mask.GetComponent<SpriteRenderer>().color.a < 0)
            Mask.GetComponent<SpriteRenderer>().color = new Color(Mask.GetComponent<SpriteRenderer>().color.r,
                Mask.GetComponent<SpriteRenderer>().color.g, Mask.GetComponent<SpriteRenderer>().color.b, 0);
        if (Mask.GetComponent<SpriteRenderer>().color.a > 1)
            Mask.GetComponent<SpriteRenderer>().color = new Color(Mask.GetComponent<SpriteRenderer>().color.r,
                Mask.GetComponent<SpriteRenderer>().color.g, Mask.GetComponent<SpriteRenderer>().color.b, 1);
        if (isFollowing)
        {
            GetComponent<Rigidbody2D>().velocity = (new Vector2(Player.transform.position.x, Player.transform.position.y + verticalShift) - (Vector2)transform.position);
            GetComponent<Camera>().orthographicSize += (defaultScale - this.GetComponent<Camera>().orthographicSize) * 0.01f;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = ((Vector2)CameraFollow.TargetPos - (Vector2)transform.position);
            GetComponent<Camera>().orthographicSize += (CameraFollow.targetScale - this.GetComponent<Camera>().orthographicSize) * 0.01f;
        }
	}
}