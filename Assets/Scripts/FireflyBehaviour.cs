using UnityEngine;
using System.Collections;

public class FireflyBehaviour : MonoBehaviour {

    public Vector2 maxdP;
    public float depth;
    Vector2 prevCameraPosition;
    Vector2 curCameraPosition;
    Vector2 dv;

	void Start () 
    {
        depth = Random.RandomRange(0.1f, 2.9f);   
        if(depth > 1)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 7;
        }
	}
	
	void Update () 
    {
        Vector2 curCameraPosition = (Vector2)Camera.main.transform.position;
	    if(prevCameraPosition != curCameraPosition)
        {
            dv = curCameraPosition - prevCameraPosition;
        }
        transform.position += (Vector3)(dv * depth);
        dv = new Vector2(Random.RandomRange(-0.001f, 0.001f), Random.RandomRange(-0.001f, 0.001f));
        transform.position += (Vector3)(dv * depth);
        prevCameraPosition = curCameraPosition;
	}
}
