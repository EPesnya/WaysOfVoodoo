using UnityEngine;
using System.Collections;

public class FireballMechanics : MonoBehaviour {

    public GameObject Explosion;

    void OnCollisionEnter2D(Collision2D a)
    {
        if(a.gameObject.GetComponent<EnemyUnit>() != null)
        {
            a.gameObject.GetComponent<EnemyUnit>().setDeltaHP(-10);
        }
        GameObject tmp = Instantiate(Explosion, transform) as GameObject;
        tmp.transform.parent = null;
        tmp.transform.position = transform.position;
        Destroy(this.gameObject);
    }

}
