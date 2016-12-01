using UnityEngine;
using System.Collections;

public class FireballFollow : MonoBehaviour {

    public Transform Anchor;
    public float cooldown = 1;
    public int damage = 1;
    public float range = 1;
    public float followRange = 3;
    float lastHitTime = -10;
    bool hasEnemy = false;
    bool needToSetTarget = true;
    Transform target;
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerStay2D(Collider2D a)
    {
        if (a.gameObject.tag == "Enemy")
        {
            if (Time.time - lastHitTime > cooldown)
            {
                a.GetComponent<EnemyUnit>().setDeltaHP(-damage);
                lastHitTime = Time.time;
            }
        }
    }

	void Update () 
    {
        if(Vector2.SqrMagnitude(transform.position - Player.transform.position) > followRange * followRange)
        {
            hasEnemy = false;
            LookForEnemy();
        }
        else
            if(hasEnemy)
            {
                if (needToSetTarget)
                {
                    Anchor2.setTarget(target);
                    needToSetTarget = false;
                }
                else
                {
                    hasEnemy = false;
                }
            }
            else
            {
                LookForEnemy();
            }
        this.GetComponent<Rigidbody2D>().velocity = 4 * (Anchor.position - transform.position);
	}

    private void LookForEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length.ToString());
        foreach (GameObject enemy in enemies)
        {
            if (Vector2.SqrMagnitude(enemy.transform.position - Player.transform.position) < range * range)
            {
                target = enemy.transform;
                hasEnemy = true;
                needToSetTarget = true;
                break;
            }
        }
        if(!hasEnemy)
        {
            Anchor2.setTarget(Player.transform);
        }
    }
}
