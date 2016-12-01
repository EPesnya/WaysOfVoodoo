using UnityEngine;
using System.Collections;

public class PlayerToolkit : MonoBehaviour {

    public static GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

}
