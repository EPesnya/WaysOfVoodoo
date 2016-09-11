using UnityEngine;
using System.Collections;

public class FireballMechanics : MonoBehaviour {

    void OnCollisionEnter2D()
    {
        Destroy(this.gameObject);
        ////
    }

}
