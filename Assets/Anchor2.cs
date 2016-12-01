using UnityEngine;
using System.Collections;

public class Anchor2 : MonoBehaviour {

    public static Transform target;
    GameObject Player;

    public static void setTarget(Transform a)
    {
        target = a;
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = Player.transform;
    }

	void Update ()
    {
        if (target != null)
            transform.position = target.position;
        else
            target = Player.transform;
	}
}
