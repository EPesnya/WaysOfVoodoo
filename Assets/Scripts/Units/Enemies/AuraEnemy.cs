using UnityEngine;
using System.Collections;

public class AuraEnemy : EnemyUnit {

    public float sqRange = 10;
    float delay = 0.1f;
    float lastHitTime = -10;
    float damage = 0.1f;

    void Start () 
    {
        Init();
	}
	
	void Update () 
    {
        if(Time.time - lastHitTime > delay)
        {
            if(Vector2.SqrMagnitude(Player.transform.position - transform.position) < sqRange)
            {
                Player.GetComponent<HeroControls>().setDeltaHP((-1) * damage);
            }
            lastHitTime = Time.time;
        }
	}
}
