using UnityEngine;
using System.Collections;

public class MeleeEnemy : EnemyUnit {

    float lastAtackTime = -10;
    float atackRate = 2.5f;
    float atackRange = 2f;
    float atackDelay = 0.5f;
    float splashRadius = 0.5f;
    Vector2 targetPoint;
    bool isAtacking = false;

	void Start ()
    {
        Init();
	}
	
	void Update ()
    {
	    if(isPooled)
        {
            Vector2 tmp = Player.transform.position - transform.position;
            if (Mathf.Abs((int)tmp.x) < atackRange &&
                Mathf.Abs((int)tmp.y) < atackRange || isAtacking)
            {
                if (Time.time - lastAtackTime > atackRate && !isAtacking)
                {
                    lastAtackTime = Time.time;
                    isAtacking = true;
                    targetPoint = Player.transform.position;
                }
                if(isAtacking && Time.time - lastAtackTime > atackDelay)
                {
                    if (Mathf.Abs((int)((Vector2)Player.transform.position - targetPoint).x) < splashRadius &&
                        Mathf.Abs((int)((Vector2)Player.transform.position - targetPoint).y) < splashRadius)
                        Player.GetComponent<HeroControls>().setDeltaHP(-10);
                    isAtacking = false;
                    lastAtackTime = Time.time;
                }
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else
                GetComponent<Rigidbody2D>().velocity = tmp.normalized * movementSpeed * speedModifier;
        }
	}
}
