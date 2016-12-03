using UnityEngine;
using System.Collections;

public class FireballMechanics : MonoBehaviour {

    public GameObject Explosion;

    void OnTriggerEnter2D(Collider2D a)
    {
        string tag = a.gameObject.tag;
        if (tag == "Enemy" || tag == "Ground")
        {
            if (tag == "Enemy")
            {
                a.gameObject.GetComponent<EnemyUnit>().setDeltaHP(-10);
            }
            GameObject tmp = Instantiate(Explosion, transform) as GameObject;
            tmp.transform.parent = null;
            tmp.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
