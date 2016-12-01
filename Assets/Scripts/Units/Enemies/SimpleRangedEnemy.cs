using UnityEngine;
using System.Collections;

public class SimpleRangedEnemy : EnemyUnit {

    public GameObject bomb;

    float sqRange = 100;
    float atackRate = 2;
    float lastAtackTime = -10;

	void Start () 
    {
        Init();
	}
	
	void Update () 
    {
        if(Vector2.SqrMagnitude(Player.transform.position - transform.position) < sqRange)
	        if(Time.time - lastAtackTime > atackRate)
            {
                GameObject tmp;
                tmp = Instantiate(bomb, transform) as GameObject;
                tmp.transform.parent = null;
                tmp.transform.position = transform.position;
                tmp.GetComponent<Rigidbody2D>().velocity = (Player.transform.position - transform.position).normalized * 5;//5???
                lastAtackTime = Time.time;
            }
	}
}
