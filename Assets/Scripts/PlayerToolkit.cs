using UnityEngine;
using System.Collections;

public class PlayerToolkit : MonoBehaviour {

    public static GameObject Player;

    public static GameObject GetPlayer()
    {
        if(Player == null)
            Player = GameObject.FindGameObjectWithTag("Player");
        return Player;
    }
}
