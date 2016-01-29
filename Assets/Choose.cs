using UnityEngine;
using System.Collections;

public class Choose : MonoBehaviour {

    GameObject Player;
    public GameObject Show;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(this.transform.position.x - Player.transform.position.x) < 1.2f)
        {
            if (Mathf.Abs(this.transform.position.y - Player.transform.position.y) < 1.2f)
            {
                Show.SetActive(true);
            }
            else Show.SetActive(false);
        }
        else Show.SetActive(false);
	}
}
