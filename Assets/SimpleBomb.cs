using UnityEngine;
using System.Collections;

public class SimpleBomb : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D a)
    {
        if(a.gameObject.tag == "Player")
        {
            a.GetComponent<HeroControls>().setDeltaHP(-10);
            Destroy(this.gameObject);
        }
    }

}
