using UnityEngine;
using System.Collections;

public class MeleeFlying : EnemyUnit {

    GameObject Player;
    Vector2 targetPoint;
    float RandomShift;
    float lastAtackTime = -10;
    float atackRate = 0.5f;

    void OnTriggerStay2D(Collider2D a)
    {
        if(a.gameObject.tag == "Player")
        {
            if(Time.time - lastAtackTime > atackRate)
            {
                Player.GetComponent<HeroControls>().setDeltaHP(-1);
                lastAtackTime = Time.time;
            }
        }
    }

    void Start()
    {
        System.Random o = new System.Random();
        RandomShift = (float)o.NextDouble();
        movementSpeed = 5;
        this.gameObject.tag = "Enemy";
        curHP = hp;
        HPBar = Instantiate(HPBar, transform) as GameObject;
        HPBar.transform.parent = transform;
        HPBar.transform.position = new Vector2(transform.position.x, transform.position.y + verticalShift);
        HPBarFill = HPBar.transform.GetChild(0);
        HPBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
    {
        targetPoint = new Vector2(Player.transform.position.x + 2 * Mathf.Cos(RandomShift + Time.time * 8), Player.transform.position.y + 1 + Mathf.Sin(RandomShift + Time.time * 5));
        GetComponent<Rigidbody2D>().velocity = (targetPoint - (Vector2)transform.position).normalized * movementSpeed * speedModifier;
	}
}
