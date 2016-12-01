using UnityEngine;
using System.Collections;

public class Choose : MonoBehaviour {

    GameObject Player;
    public GameObject Eye;
    public float DistanceX = 1.2f;
    public float DistanceY = 1.2f;
    bool isTurningOff = false;
    float startOfTurningOff = -1;
    bool isWasHere = false;
    Animator Terminator;

	void Start () {
        Player = PlayerToolkit.Player;
        Terminator = Eye.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(this.transform.position.x - Player.transform.position.x) < DistanceX
            && Mathf.Abs(this.transform.position.y - Player.transform.position.y) < DistanceY)
        {
            Eye.SetActive(true);
            isWasHere = true;
        }
        else
        {
            if(isWasHere)
            {
                startOfTurningOff = Time.time;
                isTurningOff = true;
                Terminator.SetTrigger("shoutDown");
                isWasHere = false;
            }
        }
        if(isTurningOff && Time.time - startOfTurningOff > 1)
        {
            Eye.SetActive(false);
            isTurningOff = false;
        }
	}
}
