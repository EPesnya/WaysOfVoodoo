using UnityEngine;
using System.Collections;

public class ExplosionMechanics : MonoBehaviour {

    float timeOfCreation;

	void Start () {
        timeOfCreation = Time.time;	
	}
	void Update () {
        if (Time.time - timeOfCreation > 6)
            Destroy(this.gameObject);
	}
}
