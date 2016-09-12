using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    int hp { get; set; }
    string name { get; set; }
    int curHP = 45;

    public void setDeltaHP(int a)
    {
        curHP += a;
        if(curHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
