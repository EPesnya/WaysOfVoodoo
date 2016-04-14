using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {

    public float depth;
    Vector2 AnchorPos;
    Vector2 AnchorCamPos;
    Vector2 prevCameraPosition;
    Vector2 curCameraPosition;
    Vector2 dv;

	void Start () 
    {
        AnchorPos = transform.position;
        AnchorCamPos = (Vector2)Camera.main.transform.position;
        //depth = 1 / (float)(1 - depth);
	}
	
	void Update ()
    {
        Vector2 curCameraPosition = (Vector2)Camera.main.transform.position;
        if (prevCameraPosition != curCameraPosition)
        {
            dv = curCameraPosition - AnchorCamPos;
        }
        transform.position = new Vector2(AnchorPos.x + dv.x * depth, AnchorPos.y);
        prevCameraPosition = curCameraPosition;
        	
	}
}
