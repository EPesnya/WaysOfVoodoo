using UnityEngine;
using System.Collections;

public class FireTotemMechanic : MonoBehaviour {

    public GameObject fireball;

    float lastShootTime = -10;
    float delay = 2;
    float lifeTime;
    float spawnTime;
    bool isTriggerSetted = false;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        spawnTime = Time.time;
        lifeTime = 0;
    }

	void Update () 
    {
	    if(Time.time - lastShootTime > delay && lifeTime < 5)
        {
            GameObject tmp = Instantiate(fireball, transform) as GameObject;
            tmp.transform.parent = null;
            tmp.transform.position = transform.position;
            Transform minDist = transform;
            float curMin = 999999;
            foreach(GameObject c in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float t = Vector2.SqrMagnitude(c.transform.position - transform.position);
                if(t < curMin)
                {
                    curMin = t;
                    minDist = c.transform;
                }
            }
            tmp.GetComponent<Rigidbody2D>().velocity = (minDist.position - transform.position).normalized * 5;
            lastShootTime = Time.time;
        }
        else
        {
            if(!isTriggerSetted && lifeTime > 4.5f)
            {
                anim.SetTrigger("Disapear");
                isTriggerSetted = true;
            }
            if (lifeTime > 6)
                Destroy(this.gameObject);
        }
        lifeTime = Time.time - spawnTime;

	}
}
