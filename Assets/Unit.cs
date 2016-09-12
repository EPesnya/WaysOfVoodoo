using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    protected int hp = 45;
    string name { get; set; }
    protected int curHP;

    void Start()
    {
        curHP = hp;
    }

    public virtual void setDeltaHP(int a)
    {
        curHP += a;
        if(curHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
